using System.ComponentModel.DataAnnotations;

namespace GftPetCare.DTO
{
    public class ClienteDTO
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}