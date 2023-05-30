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
using GrupoClientes.Migrations;
using Microsoft.IdentityModel.Tokens;

namespace GrupoClientes.Controllers
{
    public class MenuController : Controller
    {
        private readonly Contexto _context;
          


        public MenuController(Contexto context)
        {
            _context = context;
        }

        // GET: Menu
        public async Task<IActionResult> Index()
        {
              return _context.Menu != null ? 
                          View(await _context.Menu.ToListAsync()) :
                          Problem("Entity set 'Contexto.Menu'  is null.");
        }

        //// GET: Menu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Menu == null)
            {
                return NotFound();
            }

            var menu = _context.Menu.Include(m => m.ListaDeGrupos)
                .ToList().FirstOrDefault(m => m.Id == id);

            if (menu == null)
            {
                return NotFound();
            }
            var menuVm = new MenuViewModel();
            menuVm.Id = menu.Id;
            menuVm.Descricao = menu.Descricao;
            menuVm.Url = menu.Url;
            menuVm.Grupos = new List<GrupoViewModel>();

            foreach (var item in menu.ListaDeGrupos)
            {
                GrupoViewModel grupoVm = new GrupoViewModel();
                grupoVm.Id = item.Id;
                grupoVm.Descricao = item.Descricao;

                menuVm.Grupos.Add(grupoVm);
            }

            return View(menuVm);
        }

        // GET: Menu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MenuCreateViewModel menuCreateVm)
        {
            if (ModelState.IsValid)
            {
                Menu menu = new Menu();
                menu.Descricao = menuCreateVm.Descricao;
                menu.Url = menuCreateVm.Url;

                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menuCreateVm);
        }

        // GET: Menu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var menu =  _context.Menu.Include(m => m.ListaDeGrupos)
                .ToList().FirstOrDefault(m => m.Id == id);     

            if (id == null || _context.Menu == null)
            {
                return NotFound();
            }

            if (menu == null)
            {
                return NotFound();
            }

            var menuVm = new MenuViewModel();
            menuVm.Id = menu.Id;
            menuVm.Descricao = menu.Descricao;
            menuVm.Url = menu.Url;

            menuVm.Grupos = new List<GrupoViewModel>();
            menuVm.GruposDisponiveis = new List<GrupoViewModel>();

            foreach (var item in menu.ListaDeGrupos)
            {
                GrupoViewModel grupoVm = new GrupoViewModel();
                grupoVm.Id = item.Id;
                grupoVm.Descricao = item.Descricao;

                menuVm.Grupos.Add(grupoVm);
            }

            var GrupoArray = menu.ListaDeGrupos.Select(m =>  m.Id).ToArray();

            var gruposDisponiveis = _context.Grupo.
                Where(g => !GrupoArray.Contains(g.Id)).ToList();

            foreach (var item in gruposDisponiveis)
            {
                GrupoViewModel grupoVm = new GrupoViewModel();

                grupoVm.Id = item.Id;
                grupoVm.Descricao = item.Descricao;

                menuVm.GruposDisponiveis.Add(grupoVm);
            }

            return View(menuVm);
        }

        // POST: Menu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MenuViewModel menuVm)
        {
            var menu = await _context.Menu.
                FirstOrDefaultAsync(m => m.Id == menuVm.Id);

            if (menu == null)
            {
                return NotFound();
            }
            else
            {
                menu.Descricao = menuVm.Descricao;
                menu.Url = menuVm.Url;
            }

            ModelState.Remove("Grupos");
            ModelState.Remove("GruposDisponiveis");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.Id))
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
            return View(menu);
        }
        public async Task<IActionResult> AdicionarGrupos(MenuViewModel menuVm)
        {
            var menu = _context.Menu.Include(m => m.ListaDeGrupos)
                .FirstOrDefault(g => g.Id == menuVm.Id);

            if (menu != null)
            {
                var grupo = _context.Grupo.Include(m => m.ListaDeMenus)
                    .FirstOrDefault(g => g.Id == menuVm.IdGrupo);

                if (grupo != null)
                {
                    menu.ListaDeGrupos.Add(grupo);
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", new { id = menuVm.Id });
        }

        // GET: Menu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var menu = _context.Menu.Include(g => g.ListaDeGrupos)
                .FirstOrDefault(m => m.Id == id);

            if (id == null || _context.Menu == null)
            {
                return NotFound();
            }          

            if (menu == null)
            {
                return NotFound();
            }

            var menuVm = new MenuViewModel();
            menuVm.Id = menu.Id;
            menuVm.Descricao = menu.Descricao;
            menuVm.Url = menu.Url;

            menuVm.Grupos = new List<GrupoViewModel>();

            foreach (var item in menu.ListaDeGrupos)
            {
                GrupoViewModel grupoVm = new GrupoViewModel();
                grupoVm.Id = item.Id;
                grupoVm.Descricao = item.Descricao;
                menuVm.Grupos.Add(grupoVm);
            }

            return View(menuVm);
        }

        // POST: Menu/Delete/5
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Menu == null)
            {
                return Problem("Entity set 'Contexto.Menu'  is null.");
            }
            var menu = await _context.Menu.FindAsync(id);
            if (menu != null)
            {
                _context.Menu.Remove(menu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeletarGrupos(MenuViewModel menuVm)
        {

            var menu = _context.Menu.Include(g => g.ListaDeGrupos)
                .FirstOrDefault(m => m.Id == menuVm.Id);

            if (menu != null)
            {
                var grupo = _context.Grupo.Include(m => m.ListaDeMenus)
                            .FirstOrDefault(g => g.Id == menuVm.IdGrupo);

                if (grupo != null)
                {
                    menu.ListaDeGrupos.Remove(grupo);
                }
            }              
            await _context.SaveChangesAsync();
            return RedirectToAction("Delete", new { id = menuVm.Id });
        }

        private bool MenuExists(int id)
        {
          return (_context.Menu?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
