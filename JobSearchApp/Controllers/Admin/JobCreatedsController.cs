using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSearchApp.Data;
using JobSearchApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace JobSearchApp.Controllers.Admin
{
    [Authorize]
    public class JobCreatedsController : Controller
    {
        private readonly JobSearchDbContext _context;

        public JobCreatedsController(JobSearchDbContext context)
        {
            _context = context;
        }

        // GET: JobCreateds
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobCreated.ToListAsync());
        }

        // GET: JobCreateds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCreated = await _context.JobCreated
                .FirstOrDefaultAsync(m => m.JobCreatedID == id);
            if (jobCreated == null)
            {
                return NotFound();
            }

            return View(jobCreated);
        }

        // GET: JobCreateds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobCreateds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobCreatedID,UserID,JobPostingID")] JobCreated jobCreated)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobCreated);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobCreated);
        }

        // GET: JobCreateds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCreated = await _context.JobCreated.FindAsync(id);
            if (jobCreated == null)
            {
                return NotFound();
            }
            return View(jobCreated);
        }

        // POST: JobCreateds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobCreatedID,UserID,JobPostingID")] JobCreated jobCreated)
        {
            if (id != jobCreated.JobCreatedID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobCreated);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobCreatedExists(jobCreated.JobCreatedID))
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
            return View(jobCreated);
        }

        // GET: JobCreateds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCreated = await _context.JobCreated
                .FirstOrDefaultAsync(m => m.JobCreatedID == id);
            if (jobCreated == null)
            {
                return NotFound();
            }

            return View(jobCreated);
        }

        // POST: JobCreateds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobCreated = await _context.JobCreated.FindAsync(id);
            _context.JobCreated.Remove(jobCreated);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobCreatedExists(int id)
        {
            return _context.JobCreated.Any(e => e.JobCreatedID == id);
        }
    }
}
