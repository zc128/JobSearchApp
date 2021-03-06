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
{   [Authorize]
    public class JobPostingsController : Controller
    {
        private readonly JobSearchDbContext _context;

        public JobPostingsController(JobSearchDbContext context)
        {
            _context = context;
        }

        // GET: JobPostings
        public async Task<IActionResult> Index()
        {
            var jobSearchDbContext = _context.JobPostings.Include(j => j.Employer);
            return View(await jobSearchDbContext.ToListAsync());
        }

        // GET: JobPostings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobPosting = await _context.JobPostings
                .Include(j => j.Employer)
                .FirstOrDefaultAsync(m => m.JobPostingID == id);
            if (jobPosting == null)
            {
                return NotFound();
            }

            return View(jobPosting);
        }

        // GET: JobPostings/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Employers, "UserID", "Company");
            return View();
        }

        // POST: JobPostings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        //This is the create Job function and tracks the Jobs that the current logged-in user has created
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobPostingID,Company,Description,CompanyAddress,Email,Salary,UserID")] JobPosting jobPosting)
        {
          
            if (ModelState.IsValid)
            {
                
                _context.Add(jobPosting);

                await _context.SaveChangesAsync();
                JobCreated jobCreated = new JobCreated();
                jobCreated.UserID = User.Identity.Name;
                jobCreated.JobPostingID = jobPosting.JobPostingID;
                _context.Add(jobCreated);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Employers, "UserID", "Company", jobPosting.UserID);
            return View(jobPosting);
        }
        //This is the apply for job function, currently not working with unsolved exception.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply(JobPosting jobPosting)
        {

            if (ModelState.IsValid)
            {

                _context.Add(jobPosting);
                await _context.SaveChangesAsync();
                AppliedJob appliedJob = new AppliedJob();
                appliedJob.UserID = User.Identity.Name;
                appliedJob.JobPostingID = jobPosting.JobPostingID;
                _context.Add(appliedJob);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Employers, "UserID", "Company", jobPosting.UserID);
            return View(jobPosting);
        }

        // GET: JobPostings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobPosting = await _context.JobPostings.FindAsync(id);
            if (jobPosting == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Employers, "UserID", "Company", jobPosting.UserID);
            return View(jobPosting);
        }

        // POST: JobPostings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobPostingID,Company,Description,CompanyAddress,Email,Salary,UserID")] JobPosting jobPosting)
        {
            if (id != jobPosting.JobPostingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobPosting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobPostingExists(jobPosting.JobPostingID))
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
            ViewData["UserID"] = new SelectList(_context.Employers, "UserID", "Company", jobPosting.UserID);
            return View(jobPosting);
        }

        // GET: JobPostings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobPosting = await _context.JobPostings
                .Include(j => j.Employer)
                .FirstOrDefaultAsync(m => m.JobPostingID == id);
            if (jobPosting == null)
            {
                return NotFound();
            }

            return View(jobPosting);
        }

        // POST: JobPostings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobPosting = await _context.JobPostings.FindAsync(id);
            _context.JobPostings.Remove(jobPosting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobPostingExists(int id)
        {
            return _context.JobPostings.Any(e => e.JobPostingID == id);
        }
    }
}
