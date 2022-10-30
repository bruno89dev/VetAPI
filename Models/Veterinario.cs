using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GftPetCare.Models
{
    public class Veterinario
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public string DocIdentificacao { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Senha { get; set; }
        public string Especialidade { get; set; }
        public bool RegistroAtivo { get; set; }
    }
}