using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchApp.Models
{
    public class SavedSearch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SavedSearchID { get; set; }
        public int? CandidateID { get; set; }
        [ForeignKey("UserID")]
        public Candidate Candidate { get; set; }
        public int? EmployerID { get; set; }
        [ForeignKey("UserID")]
        public Employer Employer { get; set; }
        [StringLength(4000)]
        public string SearchedTerm { get; set; }
    }
}
