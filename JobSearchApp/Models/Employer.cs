using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchApp.Models
{
    public class Employer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        [StringLength(500)]
        public string FullName { get; set; }
        [StringLength(1000)]
        public string Company { get; set; }
        [StringLength(1000)]
        public string JobTitle { get; set; }
        [StringLength(1000)]
        public string Email { get; set; }
        [StringLength(1000)]
        public string Phone { get; set; }
        [StringLength(500)]
        public string YearEstablished { get; set; }
        [StringLength(4000)]
        public string Biography { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<JobPosting> JobPostings { get; set; }
        public ICollection<SavedSearch> SavedSearches { get; set; }

    }
}
