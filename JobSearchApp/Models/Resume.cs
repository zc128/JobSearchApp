using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchApp.Models
{
    public class Resume
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResumeID { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public Candidate Candidate { get; set; }
        [StringLength(1000)]
        public string Language { get; set; }
        [StringLength(1000)]
        public string Email { get; set; }
        [StringLength(1000)]
        public string Phone { get; set; }
        [StringLength(1000)]
        public string HighestEducation { get; set; }
        [StringLength(1000)]
        public string WorkExperience { get; set; }
        [StringLength(1000)]
        public string Skills { get; set; }
        public ICollection<JobApplication> JobApplications { get; set; }
    }
}
