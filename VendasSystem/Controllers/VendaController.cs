using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VendasSystem.Data;
using VendasSystem.Models;
using VendasSystem.ViewModels;

namespace VendasSystem.Controllers
{
    public class NotaDeVendaController : Controller
    {
        private readonly AppDbContext _context;

        public NotaDeVendaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: NotaDeVenda
        public async Task<IActionResult> Index()
        {
            return View(await _context.NotasDeVenda.ToListAsync());
        }

        // GET: NotaDeVenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotasDeVenda
                .Include(v => v.Cliente)
                .Include(v => v.Transportadora)
                .Include(v => v.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }

            return View(notaDeVenda);
        }

        // GET: NotaDeVenda/Create
        public IActionResult Create()
        {

            var viewModel = new VendaCreateEdit()
            {
                Venda = new NotaDeVenda(),
                ClientesDisponiveis = _context.Clientes.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList(),
                ProdutosDisponiveis = _context.Produtos.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList(),
                TransportadorasDisponiveis = _context.Transportadoras.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList(),
                VendedoresDisponiveis = _context.Vendedores.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList()
            };


            return View(viewModel);
        }

        // POST: NotaDeVenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind()] VendaCreateEdit viewModel)
        {

            ModelState["Venda.Transportadora"].ValidationState = ModelValidationState.Valid;
            ModelState["Venda.Vendedor"].ValidationState = ModelValidationState.Valid;
            ModelState["Venda.Cliente"].ValidationState = ModelValidationState.Valid;

            if (ModelState.IsValid)
            {
                viewModel.Venda.Data = viewModel.Venda.Data.ToUniversalTime();
                _context.Add(viewModel.Venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        // GET: NotaDeVenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotasDeVenda.FindAsync(id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }


            var viewModel = new VendaCreateEdit()
            {
                Venda = notaDeVenda,
                ClientesDisponiveis = _context.Clientes.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList(),
                ProdutosDisponiveis = _context.Produtos.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList(),
                TransportadorasDisponiveis = _context.Transportadoras.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList(),
                VendedoresDisponiveis = _context.Vendedores.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList()
            };

            return View(viewModel);
        }

        // POST: NotaDeVenda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind()] VendaCreateEdit viewModel)
        {
            ModelState["Venda.Transportadora"].ValidationState = ModelValidationState.Valid;
            ModelState["Venda.Vendedor"].ValidationState = ModelValidationState.Valid;
            ModelState["Venda.Cliente"].ValidationState = ModelValidationState.Valid;

            if (id != viewModel.Venda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    viewModel.Venda.Data = viewModel.Venda.Data.ToUniversalTime();
                    _context.Update(viewModel.Venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaDeVendaExists(viewModel.Venda.Id))
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
            return View(viewModel);
        }

        // GET: NotaDeVenda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotasDeVenda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }

            return View(notaDeVenda);
        }

        // POST: NotaDeVenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notaDeVenda = await _context.NotasDeVenda.FindAsync(id);
            if (notaDeVenda != null)
            {
                _context.NotasDeVenda.Remove(notaDeVenda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaDeVendaExists(int id)
        {
            return _context.NotasDeVenda.Any(e => e.Id == id);
        }
    }
}
