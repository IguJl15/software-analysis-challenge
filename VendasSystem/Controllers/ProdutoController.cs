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
    public class ProdutoController : Controller
    {
        private readonly Data.AppDbContext _context;

        public ProdutoController(Data.AppDbContext context)
        {
            _context = context;
        }

        // GET: Produto
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.Include(p => p.Marca).ToListAsync());
        }

        // GET: Produto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produto/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new ProdutoCreateEdit()
            {
                MarcasDisponiveis = [.. _context.Marcas.Select(
                    marca => new SelectListItem()
                    {
                        Value = marca.Id.ToString(),
                        Text = marca.Nome
                    }
                )]
            };
            return View(viewModel);
        }

        // POST: Produto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Preco,MarcaId")] ProdutoCreateEdit produto)
        {
            ModelState["Marca"]!.ValidationState = ModelValidationState.Valid;
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) { return NotFound(); }

            var produto = await _context.Produtos.Include(p => p.Marca).SingleAsync(p => p.Id == id);

            if (produto == null) { return NotFound(); }

            var viewModel = new ProdutoCreateEdit()
            {
                MarcasDisponiveis = [.. _context.Marcas.Select(
                    marca => new SelectListItem()
                    {
                        Value = marca.Id.ToString(),
                        Text = marca.Nome,
                        Selected = marca.Id == produto.MarcaId,
                    }
                )],

                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Marca = produto.Marca,
                MarcaId = produto.Marca.Id,
                Preco = produto.Preco,
            };

            System.Console.WriteLine(produto.Marca.Id);

            return View(viewModel);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Preco,MarcaId")] ProdutoCreateEdit produto)
        {
            if (id != produto.Id) return NotFound();

            ModelState["Marca"]!.ValidationState = ModelValidationState.Valid;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
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

            return View(produto);
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
