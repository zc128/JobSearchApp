using JobSearchApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearchApp.Data
{
    public class JobSearchDbContext : DbContext
    {
        public JobSearchDbContext(DbContextOptions<JobSearchDbContext> options)
            : base(options)
        {}

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<SavedSearch> SavedSearches { get; set; }
        public DbSet<AppliedJob> AppliedJob { get; set; }
        public DbSet<JobCreated> JobCreated { get; set; }
    }
}
