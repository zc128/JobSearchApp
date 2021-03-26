using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSearchApp.Data;
using JobSearchApp.Models;

namespace JobSearchApp.Controllers
{
    public class JobApplicationsController : Controller
    {
        private readonly JobSearchDbContext _context;

        public JobApplicationsController(JobSearchDbContext context)
        {
            _context = context;
        }

        // GET: JobApplications
        public async Task<IActionResult> Index()
        {
            var jobSearchDbContext = _context.JobApplications.Include(j => j.Candidate).Include(j => j.JobPosting);
            return View(await jobSearchDbContext.ToListAsync());
        }

        // GET: JobApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplications
                .Include(j => j.Candidate)
                .Include(j => j.JobPosting)
                .FirstOrDefaultAsync(m => m.ApplicationID == id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            return View(jobApplication);
        }

        // GET: JobApplications/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Candidates, "UserID", "FullName");
            ViewData["JobPostingID"] = new SelectList(_context.JobPostings, "JobPostingID", "JobPostingID");
            return View();
        }

        // POST: JobApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationID,Date,JobPostingID,UserID")] JobApplication jobApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Candidates, "UserID", "FullName", jobApplication.UserID);
            ViewData["JobPostingID"] = new SelectList(_context.JobPostings, "JobPostingID", "JobPostingID", jobApplication.JobPostingID);
            return View(jobApplication);
        }

        // GET: JobApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplications.FindAsync(id);
            if (jobApplication == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Candidates, "UserID", "FullName", jobApplication.UserID);
            ViewData["JobPostingID"] = new SelectList(_context.JobPostings, "JobPostingID", "JobPostingID", jobApplication.JobPostingID);
            return View(jobApplication);
        }

        // POST: JobApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationID,Date,JobPostingID,UserID")] JobApplication jobApplication)
        {
            if (id != jobApplication.ApplicationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobApplicationExists(jobApplication.ApplicationID))
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
            ViewData["UserID"] = new SelectList(_context.Candidates, "UserID", "FullName", jobApplication.UserID);
            ViewData["JobPostingID"] = new SelectList(_context.JobPostings, "JobPostingID", "JobPostingID", jobApplication.JobPostingID);
            return View(jobApplication);
        }

        // GET: JobApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplications
                .Include(j => j.Candidate)
                .Include(j => j.JobPosting)
                .FirstOrDefaultAsync(m => m.ApplicationID == id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            return View(jobApplication);
        }

        // POST: JobApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobApplication = await _context.JobApplications.FindAsync(id);
            _context.JobApplications.Remove(jobApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobApplicationExists(int id)
        {
            return _context.JobApplications.Any(e => e.ApplicationID == id);
        }
    }
}
