using JobSearch.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Domain.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Company { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string CityState { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public string ContractType { get; set; }
        [Required]
        public string TecnologyTools { get; set; }

        public string CompanyDescription { get; set; }
        [Required]
        public string JobDescriptions { get; set; }

        public string Benefits { get; set; }

        [Required]
        [EmailAddress]
        public string OwnerEmail { get; set; }

        public DateTime PublishDate { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public virtual User? User { get; set; } 
    }
}
