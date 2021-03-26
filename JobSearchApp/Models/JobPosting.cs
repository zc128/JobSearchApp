using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchApp.Models
{
    public class JobPosting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobPostingID { get; set; }
        [StringLength(1000)]
        public string Company { get; set; }
        [StringLength(4000)]
        public string Description { get; set; }
        [StringLength(4000)]
        public string CompanyAddress { get; set; }
        [StringLength(1000)]
        public string Email { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public Employer Employer { get; set; }
        public ICollection<JobApplication> JobApplications { get; set; }
    }
}
