using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchApp.Models
{
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        [StringLength(500)]
        public string FullName { get; set; }
        [StringLength(1000)]
        public string Email { get; set; }
        [StringLength(1000)]
        public string PhoneNumber { get; set; }
        public ICollection<JobApplication> JobApplications { get; set; }
        public ICollection<SavedSearch> SavedSearches { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Resume> Resumes { get; set; }
    }
}

