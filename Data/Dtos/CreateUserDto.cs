﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Course.Data.Dtos
{
    public class CreateUserDto
    {
        [Required] // user name obrigatorio
        public string UserName { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]// camo tratado como senha
        public string Password { get; set; }

        [Required]
        [Compare("Password")]//confrimando a senha.
        public string ConfirmPassword { get; set; }

        [Required]
        public DateTime DateBirth { get; set; }


        [Required]
        public DateTime Admissiondate { get; set; }

        [Required]
        public string PhoneNumber {get; set;}
        
        [Required]
        [MaxLength(14)]
        public string CPF { get; set; } = null!;

        [Required]
        public int Registration { get; set; }//cep
        [Required]
        [MaxLength(11)]
        public string Rg { get; set; } = null!;
        [Required]
        [MaxLength(11)]
        public string Nis { get; set; } = null!;
        [Required]
        [MaxLength(11)]
        public string Pis { get; set; } = null!;
        [Required]
        public string Publicplace { get; set; } = null!;//rua
        [Required]
        public string Neighborhood { get; set; } = null!;//bairro

        
        public int? Number { get; set; }

        public string? Complement{ get; set; }
        
        [Required]
        public string City {get; set; } = null!;//cidade
        
        [Required]
        [MaxLength(2)]
        
        public string Uf { get; set; } = null!;//estado

        public string Gender { get; set; } = null!;

        [Required]
        [MaxLength (1)]
        public string Status { get; set; } = null!;

        [Required]
        [MaxLength(1)]
        public string LevelAcesse { get; set; } = null!;

        [Required]
        [Precision(18,2)]
        public decimal GrossSalary { get; set; }

        [Required]
        public string Office { get; set; } = null!;
    }
}
