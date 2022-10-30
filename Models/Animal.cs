using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GftPetCare.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public Cliente Tutor { get; set; }
        public string Raca { get; set; }
        public string Genero { get; set; }
        public int AnoDeNascimento { get; set; }
        public int Idade { get; set; }
        public double Peso { get; set; }
        public double AlturaEmCm { get; set; }
        public bool RegistroAtivo { get; set; }

    }
}