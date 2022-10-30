using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GftPetCare.Models
{
    public class Atendimento
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataDoAtendimento { get; set; }
        public Veterinario Veterinario { get; set; }
        public Animal Animal { get; set; }
        [JsonIgnore]
        public Cliente Tutor { get; set; }
        public double PesoAtual { get; set; }
        public double AlturaEmCmAtual { get; set; }
        public string Diagnostico { get; set; }
        public string ObservacoesGerais { get; set; }
        public bool IsFinalizado { get; set; }
        public bool RegistroAtivo { get; set; }
    }
}