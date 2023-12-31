﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course.Models
{
    public class Payroll
    {

        [Key]
        public int Id { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal NetSalary { get; set; }
        public decimal Fgts { get; set; }
        public decimal INSS { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Date_of_competence { get; set; }

        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        
        public User User { get; set; }
        public string UserName { get; set; }
        public decimal Desc { get; set; }
        
        public string Office { get; set; }
    }
}
