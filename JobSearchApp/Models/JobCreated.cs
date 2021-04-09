using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchApp.Models
{  //This is the table for tracking The Job Descriptions that the user has created
    public class JobCreated
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobCreatedID { get; set; }
        public string UserID { get; set; }
        public int JobPostingID { get; set; }

    }
}
