using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchApp.Models
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotificationID { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public Candidate Candidate { get; set; }
        [ForeignKey("UserID")]
        public Employer Employer { get; set; }
        [StringLength(1000)]
        public string Date { get; set; }
        [StringLength(4000)]
        public string Description { get; set; }
        [StringLength(1000)]
        public string Type { get; set; }
     
    }
}
