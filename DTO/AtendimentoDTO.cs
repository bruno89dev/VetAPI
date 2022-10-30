using System;

namespace GftPetCare.DTO
{
    public class AtendimentoDTO
    {
        public DateTime DataDoAtendimento { get; set; }
        public int VeterinarioId { get; set; }
        public int AnimalId { get; set; }
        public int TutorId { get; set; }
        public double PesoAtual { get; set; }
        public double AlturaEmCmAtual { get; set; }
        public string Diagnostico { get; set; }
        public string ObservacoesGerais { get; set; }
    }
}