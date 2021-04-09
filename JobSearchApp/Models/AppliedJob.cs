using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchApp.Models
{   //This is the table for tracking the jobs a user has applied to
    public class AppliedJob
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppliedJobID { get; set; }
        public string UserID { get; set; }
        public int JobPostingID { get; set; }

    }
}
