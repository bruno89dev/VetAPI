using GftPetCare.DTO;
using GftPetCare.Models;
using Microsoft.EntityFrameworkCore;

namespace GftPetCare.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option){
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        
    }
}