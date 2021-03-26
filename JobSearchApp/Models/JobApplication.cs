using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchApp.Models
{
    public class JobApplication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationID { get; set; }
        [StringLength(1000)]
        public string Date { get; set; }
        public int JobPostingID { get; set; }
        [ForeignKey("JobPostingID")]
        public JobPosting JobPosting { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public Candidate Candidate { get; set; }

    }
}
