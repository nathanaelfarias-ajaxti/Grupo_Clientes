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
    public class GrupoController : Controller
    {
        private readonly Contexto _context;

        public GrupoController(Contexto context)
        {
            _context = context;
        }

        //GET: Grupos
        public async Task<IActionResult> Index()
        {
            return _context.Grupo != null ?
                        View(await _context.Grupo.ToListAsync()) :
                        Problem("Entity set 'Contexto.Grupos'  is null.");
        }

        //GET: Grupos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var grupo = _context.Grupo.Include(m => m.ListaDeMenus)
                .Include(i => i.ListaDeUsuarios)
                .ToList().FirstOrDefault(g => g.Id == id);

            if (id == null || _context.Grupo == null)
            {
                return NotFound();
            }

            if (grupo == null)
            {
                return NotFound();
            }

            var grupoVm = new GrupoViewModel();
            grupoVm.Id = grupo.Id;
            grupoVm.Descricao = grupo.Descricao;

            grupoVm.Menus = new List<MenuViewModel>();
            grupoVm.Usuarios = new List<UsuarioViewModel>();

            foreach (var item in grupo.ListaDeMenus)
            {
                MenuViewModel menuVm = new MenuViewModel();
                menuVm.Id = item.Id;
                menuVm.Descricao = item.Descricao;
                menuVm.Url = item.Url;

                grupoVm.Menus.Add(menuVm);
            }

            foreach (var item in grupo.ListaDeUsuarios)
            {
                UsuarioViewModel usuarioVm = new UsuarioViewModel();
                usuarioVm.Nome = item.Nome;
                usuarioVm.Senha = item.Senha;
                usuarioVm.Email = item.Email;

                grupoVm.Usuarios.Add(usuarioVm);
            }

            return View(grupoVm);
        }

        // GET: Grupos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grupos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GrupoCreateViewModel grupoVm)
        {
            if (ModelState.IsValid)
            {
                Grupo grupo = new Grupo();
                grupo.Descricao = grupoVm.Descricao;
                _context.Add(grupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupoVm);
        }

        //GET: Grupo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var grupo =  _context.Grupo.Include(m => m.ListaDeMenus)
                .Include(i => i.ListaDeUsuarios)
                .ToList().FirstOrDefault(g => g.Id == id);

            if (id == null || _context.Grupo == null)
            {
                return NotFound();
            }           

            if (grupo == null)
            {
                return NotFound();
            }

            var grupoVm = new GrupoViewModel();
            grupoVm.Id = grupo.Id;
            grupoVm.Descricao = grupo.Descricao;

            grupoVm.Menus = new List<MenuViewModel>();
            grupoVm.MenusDisponiveis = new List<MenuViewModel>();
            grupoVm.Usuarios = new List<UsuarioViewModel>();
            grupoVm.UsuariosDisponiveis = new List<UsuarioViewModel>();

            foreach (var item in grupo.ListaDeMenus)
            {
                MenuViewModel menuVm = new MenuViewModel();
                menuVm.Id = item.Id;
                menuVm.Descricao = item.Descricao;
                menuVm.Url = item.Url;

                grupoVm.Menus.Add(menuVm);
            }

            var MenuArray = grupo.ListaDeMenus.Select(g => g.Id).ToArray();

            var menusDisponiveis = _context.Menu.
                Where(p => !MenuArray.Contains(p.Id)).ToList();

            foreach (var item in menusDisponiveis)
            {
                MenuViewModel menuVm = new MenuViewModel();

                menuVm.Id = item.Id;
                menuVm.Descricao = item.Descricao;
                menuVm.Url = item.Url;

                grupoVm.MenusDisponiveis.Add(menuVm);
            }

            foreach (var item in grupo.ListaDeUsuarios)
            {
                UsuarioViewModel usuarioVm = new UsuarioViewModel();
                usuarioVm.Id = item.Id;
                usuarioVm.Nome = item.Nome;
                usuarioVm.Senha = item.Senha;
                usuarioVm.Email = item.Email;

                grupoVm.Usuarios.Add(usuarioVm);
            }

            var UsuarioArray = grupo.ListaDeUsuarios.Select(g => g.Id).ToArray();

            var usuariosDisponiveis = _context.Usuario.
                Where(p => !UsuarioArray.Contains(p.Id)).ToList();

            foreach (var item in usuariosDisponiveis)
            {
                UsuarioViewModel usuarioVm = new UsuarioViewModel();
                usuarioVm.Id = item.Id;
                usuarioVm.Nome = item.Nome;
                usuarioVm.Senha = item.Senha;
                usuarioVm.Email = item.Email;

                grupoVm.UsuariosDisponiveis.Add(usuarioVm);
            }

            return View(grupoVm);
        }

        //POST: Grupo/Edit/5
         //To protect from overposting attacks, enable the specific properties you want to bind to.
         //For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GrupoViewModel grupoVm)
        {
            var grupo = await _context.Grupo
                .FirstOrDefaultAsync(m => m.Id == grupoVm.Id);

            if (grupo == null)
            {
                return NotFound();
            }
            else
            {
                grupo.Descricao = grupoVm.Descricao;
            }

            ModelState.Remove("Menus");
            ModelState.Remove("MenusDisponiveis");
            ModelState.Remove("Usuarios");
            ModelState.Remove("UsuariosDisponiveis");

            if (ModelState.IsValid)
            {           
                try
                {                  
                    _context.Update(grupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoExists(grupo.Id))
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
            return View(grupo);
        }

        public async Task<IActionResult> AdicionarMenus(GrupoViewModel grupoVm)
        {
            var grupo = _context.Grupo.Include(g => g.ListaDeMenus)
                .FirstOrDefault(m => m.Id == grupoVm.Id);

            if (grupo != null)
            {
                var menu = _context.Menu.Include(g => g.ListaDeGrupos)
                    .FirstOrDefault(m => m.Id == grupoVm.IdMenu);

                if (menu != null)
                {
                    grupo.ListaDeMenus.Add(menu);
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", new { id = grupoVm.Id });
        }

        public async Task<IActionResult> AdicionarUsuarios(GrupoViewModel grupoVm)
        {
            var grupo = _context.Grupo.Include(g => g.ListaDeUsuarios)
                .FirstOrDefault(m => m.Id == grupoVm.Id);

            if (grupo != null)
            {
                var usuario = _context.Usuario.Include(g => g.ListaDeGrupos)
                    .FirstOrDefault(m => m.Id == grupoVm.IdUsuario);

                if (usuario != null)
                {
                    grupo.ListaDeUsuarios.Add(usuario);
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", new { id = grupoVm.Id });
        }

        //GET: Grupos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var grupo = _context.Grupo.Include(g => g.ListaDeMenus)
                .Include(u => u.ListaDeUsuarios)
                .FirstOrDefault(m => m.Id == id);

            if (id == null || _context.Grupo == null)
            {
                return NotFound();
            }
         
            if (grupo == null)
            {
                return NotFound();
            }

            var grupoVm = new GrupoViewModel();
            grupoVm.Id = grupo.Id;
            grupoVm.Descricao = grupo.Descricao;

            grupoVm.Menus = new List<MenuViewModel>();
            grupoVm.Usuarios = new List<UsuarioViewModel>();

            foreach (var item in grupo.ListaDeMenus)
            {
                MenuViewModel menuVm = new MenuViewModel();
                menuVm.Id = item.Id;
                menuVm.Descricao = item.Descricao;
                menuVm.Url = item.Url;

                grupoVm.Menus.Add(menuVm);
            }

            foreach (var item in grupo.ListaDeUsuarios)
            {
                UsuarioViewModel usuarioVm = new UsuarioViewModel();
                usuarioVm.Id = item.Id;
                usuarioVm.Nome = item.Nome;
                usuarioVm.Senha = item.Senha;
                usuarioVm.Email = item.Email;

                grupoVm.Usuarios.Add(usuarioVm);
            }

            return View(grupoVm);
        }

        // POST: Grupos/Delete/5
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Grupo == null)
            {
                return Problem("Entity set 'Contexto.Grupos'  is null.");
            }
            var grupo = await _context.Grupo.FindAsync(id);

            if (grupo != null)
            {
                _context.Grupo.Remove(grupo);
                await _context.SaveChangesAsync();
            }         
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeletarMenus(GrupoViewModel grupoVm)
        {
            var grupo = _context.Grupo.Include(g => g.ListaDeMenus)
                .FirstOrDefault(m => m.Id == grupoVm.Id);

            if(grupo != null)
            {
                var menu = _context.Menu.Include(g => g.ListaDeGrupos)
                    .FirstOrDefault(m => m.Id == grupoVm.IdMenu);

                if(menu != null)
                {
                    grupo.ListaDeMenus.Remove(menu);
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Delete",new { id = grupoVm.Id});
        }

        public async Task<IActionResult> DeletarUsuarios(GrupoViewModel grupoVm)
        {
            var grupo = _context.Grupo.Include(g => g.ListaDeUsuarios)
                .FirstOrDefault(m => m.Id == grupoVm.Id);

            if (grupo != null)
            {
                var usuario = _context.Usuario.Include(g => g.ListaDeGrupos)
                    .FirstOrDefault(m => m.Id == grupoVm.IdUsuario);

                if (usuario != null)
                {
                    grupo.ListaDeUsuarios.Remove(usuario);
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Delete", new { id = grupoVm.Id });
        }

        private bool GrupoExists(int id)
        {
            return (_context.Grupo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
