using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchApp.Models
{
    public class AppliedJob
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppliedJobID { get; set; }
        public int UserID { get; set; }
        public int JobPostingID { get; set; }

    }
}
