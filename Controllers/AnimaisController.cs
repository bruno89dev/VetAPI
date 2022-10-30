using System.Linq;
using GftPetCare.Data;
using GftPetCare.DTO;
using GftPetCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GftPetCare.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    [Authorize(Roles = "userVet")]
    public class AnimaisController : ControllerBase
    {
        private readonly ApplicationDbContext _database;

        public AnimaisController(ApplicationDbContext database){
            _database = database;
        }

        [HttpGet("Listar")]
        public IActionResult GetAnimais(){

            var listaDeAnimais = _database.Animais.Include(tutor => tutor.Tutor).ToList();

            if (listaDeAnimais.Count == 0){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum animal encontrado!"});
            } else {
                return Ok(listaDeAnimais);
            }
        }       

        [HttpGet("PesquisaId/{Id}")]
        public IActionResult GetAnimalPorId(int Id){

            var animalPorId = _database.Animais.Include(tutor => tutor.Tutor).Where(a => a.Id == Id).ToList();

            if (animalPorId.Count == 0){
                Response.StatusCode = 404;
                return new ObjectResult(new { info = "Animal não encontrado!"});
            } else {
                return Ok(animalPorId);
            }
        }

        [HttpGet("PesquisaNome/{Nome}")]
        public IActionResult GetAnimaisPorNome(string Nome){

            var animaisPorNome = _database.Animais.Include(tutor => tutor.Tutor).Where(aNome => aNome.Nome.Contains(Nome)).ToList();

            if (animaisPorNome.Count == 0){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum animal encontrado!"});
            } else {
                return Ok(animaisPorNome);
            }
        }

        [HttpGet("PesquisaRaca/{Raca}")]
        public IActionResult GetAnimalPorRaca(string Raca){

            var animalPorRaca = _database.Animais.Include(tutor => tutor.Tutor).Where(a => a.Raca.Contains(Raca)).ToList();

            if(animalPorRaca.Count == 0){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum animal encontrado com a raça pesquisada!"});
            } else {
                return Ok(animalPorRaca);
            }
        }

        [HttpPost("Cadastrar")]
        public IActionResult CadastrarAnimal([FromBody] AnimalDTO animalTemp){

            Animal animal = new Animal();
            int anoAtual = 2022;

            animal.Nome = animalTemp.Nome;
            animal.Tutor = _database.Clientes.First(tutorAnimal => tutorAnimal.Id == animalTemp.TutorId);
            animal.Raca = animalTemp.Raca;
            animal.Genero = animalTemp.Genero;
            animal.Idade = anoAtual - animal.AnoDeNascimento;
            animal.Peso = animalTemp.Peso;
            animal.AlturaEmCm = animalTemp.AlturaEmCm;
            animal.RegistroAtivo = true;
            _database.Animais.Add(animal);
            _database.SaveChanges();
            Response.StatusCode = 201;
            return new ObjectResult(new{info = "Animal adicionado com sucesso"});
        }

        [HttpPatch("Atualizar")]
        public IActionResult AtualizarAnimal([FromBody] Animal animal){

            if (animal.Id != 0){

                var animalPatch = _database.Animais.First(atualizaAnimal => atualizaAnimal.Id == animal.Id);

                if(animalPatch != null){

                    animalPatch.Nome = animal.Nome != null ? animal.Nome : animalPatch.Nome;
                    animalPatch.Tutor = animal.Tutor != null ? animal.Tutor : animalPatch.Tutor;
                    animalPatch.Raca = animal.Raca != null ? animal.Raca : animalPatch.Raca;
                    animalPatch.Genero = animal.Genero != null ? animal.Genero : animalPatch.Genero;
                    animalPatch.AnoDeNascimento = animal.AnoDeNascimento != 0 ? animal.AnoDeNascimento : animalPatch.AnoDeNascimento;
                    animalPatch.Peso = animal.Peso != 0 ? animal.Peso : animalPatch.Peso;
                    animalPatch.AlturaEmCm = animal.AlturaEmCm != 0 ? animal.AlturaEmCm : animalPatch.AlturaEmCm;
                
                    animalPatch.RegistroAtivo = animal.RegistroAtivo != false ? animal.RegistroAtivo : animalPatch.RegistroAtivo;
                    _database.SaveChanges();
                    return Ok("Animal atualizado com sucesso!");

                } else {

                    Response.StatusCode = 403;
                    return new ObjectResult(new {info = "Animal não encontrado!"});
                }
            }
                Response.StatusCode = 403;
                return new ObjectResult(new {info = "Animal não encontrado!"});
        }

        [HttpDelete("Excluir/{Id}")]
        public IActionResult DeletarAnimal(int Id){

            Animal animal = _database.Animais.First(a => a.Id == Id);

            animal.RegistroAtivo = false;
            _database.SaveChanges();
            return Ok("Registro de animal excluído com sucesso!");
        }
    }
}