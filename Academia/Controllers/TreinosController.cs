﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Academia;
using Academia.Models;

namespace Academia.Controllers
{
    public class TreinosController : Controller
    {
        private readonly AcademiaContext _context;

        public TreinosController(AcademiaContext context)
        {
            _context = context;
        }

        // GET: Treinos
        public async Task<IActionResult> Index()
        {
            var academiaContext = _context.Treino.Include(t => t.Aluno);
            return View(await academiaContext.ToListAsync());
        }

        // GET: Treinos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treino = await _context.Treino
                .Include(t => t.Aluno)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treino == null)
            {
                return NotFound();
            }

            return View(treino);
        }

        // GET: Treinos/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Aluno, "Id", "Email");
            return View();
        }

        // POST: Treinos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataInicio,DataFim,Progresso")] Treino treino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Aluno, "Id", "Email", treino.Id);
            return View(treino);
        }

        // GET: Treinos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treino = await _context.Treino.FindAsync(id);
            if (treino == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Aluno, "Id", "Email", treino.Id);
            return View(treino);
        }

        // POST: Treinos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataInicio,DataFim,Progresso")] Treino treino)
        {
            if (id != treino.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreinoExists(treino.Id))
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
            ViewData["Id"] = new SelectList(_context.Aluno, "Id", "Email", treino.Id);
            return View(treino);
        }

        // GET: Treinos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treino = await _context.Treino
                .Include(t => t.Aluno)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treino == null)
            {
                return NotFound();
            }

            return View(treino);
        }

        // POST: Treinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treino = await _context.Treino.FindAsync(id);
            _context.Treino.Remove(treino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreinoExists(int id)
        {
            return _context.Treino.Any(e => e.Id == id);
        }
    }
}
