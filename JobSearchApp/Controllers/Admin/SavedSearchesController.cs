﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSearchApp.Data;
using JobSearchApp.Models;

namespace JobSearchApp.Controllers.Admin
{
    public class SavedSearchesController : Controller
    {
        private readonly JobSearchDbContext _context;

        public SavedSearchesController(JobSearchDbContext context)
        {
            _context = context;
        }

        // GET: SavedSearches
        public async Task<IActionResult> Index()
        {
            return View(await _context.SavedSearches.ToListAsync());
        }

        // GET: SavedSearches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedSearch = await _context.SavedSearches
                .FirstOrDefaultAsync(m => m.SavedSearchID == id);
            if (savedSearch == null)
            {
                return NotFound();
            }

            return View(savedSearch);
        }

        // GET: SavedSearches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SavedSearches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SavedSearchID,CandidateID,EmployerID,SearchedTerm")] SavedSearch savedSearch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(savedSearch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(savedSearch);
        }

        // GET: SavedSearches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedSearch = await _context.SavedSearches.FindAsync(id);
            if (savedSearch == null)
            {
                return NotFound();
            }
            return View(savedSearch);
        }

        // POST: SavedSearches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SavedSearchID,CandidateID,EmployerID,SearchedTerm")] SavedSearch savedSearch)
        {
            if (id != savedSearch.SavedSearchID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(savedSearch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SavedSearchExists(savedSearch.SavedSearchID))
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
            return View(savedSearch);
        }

        // GET: SavedSearches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedSearch = await _context.SavedSearches
                .FirstOrDefaultAsync(m => m.SavedSearchID == id);
            if (savedSearch == null)
            {
                return NotFound();
            }

            return View(savedSearch);
        }

        // POST: SavedSearches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var savedSearch = await _context.SavedSearches.FindAsync(id);
            _context.SavedSearches.Remove(savedSearch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SavedSearchExists(int id)
        {
            return _context.SavedSearches.Any(e => e.SavedSearchID == id);
        }
    }
}
