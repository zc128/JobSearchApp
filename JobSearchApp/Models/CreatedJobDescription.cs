using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchApp.Models
{
    public class CreatedJobDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CreatedJobDescriptionID { get; set; }
        public int UserID { get; set; }
        [StringLength(4000)]
        public string Description { get; set; }

    }
}
