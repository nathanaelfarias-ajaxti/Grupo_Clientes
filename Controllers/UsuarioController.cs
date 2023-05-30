using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrupoClientes.Data;
using GrupoClientes.Models;
using GrupoClientes.ViewsModel;
using System.Text.RegularExpressions;

namespace GrupoClientes.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Contexto _context;

        public UsuarioController(Contexto context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
              return _context.Usuario != null ? 
                          View(await _context.Usuario.ToListAsync()) :
                          Problem("Entity set 'Contexto.Usuario'  is null.");
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var usuario = _context.Usuario.Include(g => g.ListaDeGrupos).
                FirstOrDefault(g => g.Id == id);

            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }
            
            if (usuario == null)
            {
                return NotFound();
            }
            var usuarioVm = new UsuarioViewModel();
            usuarioVm.Id = usuario.Id;
            usuarioVm.Nome = usuario.Nome;
            usuarioVm.Senha = usuario.Senha;
            usuarioVm.Email = usuario.Email;
            usuarioVm.Grupos = new List<GrupoViewModel>();

            foreach (var item in usuario.ListaDeGrupos)
            {
                GrupoViewModel grupoVm = new GrupoViewModel();
                grupoVm.Id = item.Id;
                grupoVm.Descricao = item.Descricao;

                usuarioVm.Grupos.Add(grupoVm);
            }

            return View(usuarioVm);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioCreateViewModel usuarioVm)
        {
  
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario();
                usuario.Nome = usuarioVm.Nome;
                usuario.Senha = usuarioVm.Senha;    
                usuario.Email = usuarioVm.Email;
                
                _context.Add(usuario);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(usuarioVm);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var usuario =  _context.Usuario.Include(g => g.ListaDeGrupos).
                FirstOrDefault(g => g.Id == id);

            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioVm = new UsuarioViewModel();
            usuarioVm.Id = usuario.Id;
            usuarioVm.Nome = usuario.Nome;
            usuarioVm.Senha = usuario.Senha;
            usuarioVm.Email = usuario.Email;

            usuarioVm.Grupos = new List<GrupoViewModel>();
            usuarioVm.GruposDisponiveis = new List<GrupoViewModel>();

            foreach (var item in usuario.ListaDeGrupos)
            {
                GrupoViewModel grupoVm = new GrupoViewModel();
                grupoVm.Id = item.Id;
                grupoVm.Descricao = item.Descricao;

                usuarioVm.Grupos.Add(grupoVm);
            }

            var GrupoArray = usuario.ListaDeGrupos.Select(u => u.Id).ToArray();

            var gruposDisponiveis = _context.Grupo.
                Where(g => !GrupoArray.Contains(g.Id)).ToList();

            foreach (var item in gruposDisponiveis)
            {
                GrupoViewModel grupoVm = new GrupoViewModel();

                grupoVm.Id = item.Id;
                grupoVm.Descricao = item.Descricao;

                usuarioVm.GruposDisponiveis.Add(grupoVm);
            }

            return View(usuarioVm);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UsuarioViewModel usuarioVm)
        {
            var usuario = await _context.Usuario.
                FirstOrDefaultAsync(m => m.Id == usuarioVm.Id);

            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                usuario.Nome = usuarioVm.Nome;
                usuario.Senha = usuarioVm.Senha;
                usuario.Email = usuarioVm.Email;
            }

            ModelState.Remove("Grupos");
            ModelState.Remove("GruposDisponiveis");

            if (ModelState.IsValid)
            {
                try
                {                  
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }
        public async Task<IActionResult> AdicionarGrupos(UsuarioViewModel usuarioVm)
        {
            try {
                var usuario = _context.Usuario
        .FirstOrDefault(g => g.Id == usuarioVm.Id); 

                if (usuario != null)
                {
                    var grupo = _context.Grupo.Include(m => m.ListaDeUsuarios)
                        .FirstOrDefault(g => g.Id == usuarioVm.IdGrupo);

                    if (grupo != null)
                    {
                        usuario.ListaDeGrupos.Add(grupo);
                    }
                }
                await _context.SaveChangesAsync();
               
            }
            catch (Exception e) {
                var x = e.Message;
            }
            return RedirectToAction("Edit", new { id = usuarioVm.Id });
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var usuario = await _context.Usuario.Include(g => g.ListaDeGrupos)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }
            
            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioVm = new UsuarioViewModel();
            usuarioVm.Id = usuario.Id;
            usuarioVm.Nome = usuario.Nome;
            usuarioVm.Senha = usuario.Senha;
            usuarioVm.Email = usuario.Email;

            usuarioVm.Grupos = new List<GrupoViewModel>();

            foreach (var item in usuario.ListaDeGrupos)
            {
                GrupoViewModel grupoVm = new GrupoViewModel();
                grupoVm.Id = item.Id;
                grupoVm.Descricao = item.Descricao;

                usuarioVm.Grupos.Add(grupoVm);
            }

            return View(usuarioVm);
        }

        // POST: Usuario/Delete/5
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuario == null)
            {
                return Problem("Entity set 'Contexto.Usuario'  is null.");
            }
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeletarGrupos(UsuarioViewModel usuarioVm)
        {
            var usuario = _context.Usuario.Include(g => g.ListaDeGrupos)
                .FirstOrDefault(m => m.Id == usuarioVm.Id);

            if (usuario != null)
            {
                var grupo = _context.Grupo.Include(g => g.ListaDeUsuarios)
                    .FirstOrDefault(m => m.Id == usuarioVm.IdGrupo);

                if (grupo != null)
                {
                    usuario.ListaDeGrupos.Remove(grupo);
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Delete", new { id = usuarioVm.Id });
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuario?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
