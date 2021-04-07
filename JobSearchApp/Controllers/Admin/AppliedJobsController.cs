using System;
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
    public class AppliedJobsController : Controller
    {
        private readonly JobSearchDbContext _context;

        public AppliedJobsController(JobSearchDbContext context)
        {
            _context = context;
        }

        // GET: AppliedJobs
        public async Task<IActionResult> Index()
        {
            return View(await _context.AppliedJob.ToListAsync());
        }

        // GET: AppliedJobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appliedJob = await _context.AppliedJob
                .FirstOrDefaultAsync(m => m.AppliedJobID == id);
            if (appliedJob == null)
            {
                return NotFound();
            }

            return View(appliedJob);
        }

        // GET: AppliedJobs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppliedJobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppliedJobID,UserID,JobPostingID")] AppliedJob appliedJob)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appliedJob);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appliedJob);
        }

        // GET: AppliedJobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appliedJob = await _context.AppliedJob.FindAsync(id);
            if (appliedJob == null)
            {
                return NotFound();
            }
            return View(appliedJob);
        }

        // POST: AppliedJobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppliedJobID,UserID,JobPostingID")] AppliedJob appliedJob)
        {
            if (id != appliedJob.AppliedJobID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appliedJob);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppliedJobExists(appliedJob.AppliedJobID))
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
            return View(appliedJob);
        }

        // GET: AppliedJobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appliedJob = await _context.AppliedJob
                .FirstOrDefaultAsync(m => m.AppliedJobID == id);
            if (appliedJob == null)
            {
                return NotFound();
            }

            return View(appliedJob);
        }

        // POST: AppliedJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appliedJob = await _context.AppliedJob.FindAsync(id);
            _context.AppliedJob.Remove(appliedJob);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppliedJobExists(int id)
        {
            return _context.AppliedJob.Any(e => e.AppliedJobID == id);
        }
    }
}
