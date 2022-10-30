using System;

namespace GftPetCare.DTO
{
    public class AnimalDTO
    {
        public string Nome { get; set; }
        public int TutorId { get; set; }
        public string Raca { get; set; }
        public string Genero { get; set; }
        public int AnoDeNascimento { get; set; }
        public int Idade { get; set; }
        public double Peso { get; set; }
        public double AlturaEmCm { get; set; }
        
    }
}