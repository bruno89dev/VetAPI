using System.Linq;
using GftPetCare.Data;
using GftPetCare.DTO;
using GftPetCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GftPetCare.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    [Authorize(Roles = "userVet")]
    public class VeterinariosController : ControllerBase
    {
        private readonly ApplicationDbContext _database;

        public VeterinariosController(ApplicationDbContext database){
            _database = database;
        }

        [HttpGet("Listar")]
        public IActionResult GetVets(){

            var listaDeVets = _database.Veterinarios.ToList();

            if (listaDeVets.Count == 0){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum veterinário encontrado!"});
            } else {
                return Ok(listaDeVets);
            }
        }

        [HttpGet("PesquisaId/{Id}")]
        public IActionResult GetVetPorId(int Id){

            var vetPorId = _database.Veterinarios.First(v => v.Id == Id);

            if (vetPorId.RegistroAtivo != true){
                Response.StatusCode = 404;
                return new ObjectResult(new { info = "Cliente não encontrado!"});
            } else {
                return Ok(vetPorId);
            }
        }

        [HttpGet("PesquisaDoc/{DocId}")]
        public IActionResult GetVetPorDocId(string DocId){

            var vetPorDocId = _database.Veterinarios.Where(vetDoc => vetDoc.DocIdentificacao.Contains(DocId)).ToList();

            if(vetPorDocId.Count == 0){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum veterinário encontrado com o documento pesquisado!"});
            } else {
                return Ok(vetPorDocId);
            }
        }

        [HttpGet("PesquisaNome/{Nome}")]
        public IActionResult GetVetPorNome(string Nome){

            var vetPorNome = _database.Veterinarios.Where(nVet => nVet.Nome.Contains(Nome)).ToList();

            if(vetPorNome.Count == 0){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum veterinário encontrado com o nome pesquisado!"});
            } else {
                return Ok(vetPorNome);
            }
        }

        [HttpPost("Cadastrar")]
        public IActionResult CadastrarVeterinario([FromBody] VeterinarioDTO vetTemp){

            Veterinario vet = new Veterinario();

            vet.Nome = vetTemp.Nome;
            vet.DocIdentificacao = vetTemp.DocIdentificacao;
            vet.Email = vetTemp.Email;
            vet.Senha = vetTemp.Senha;
            vet.Especialidade = vetTemp.Especialidade;
            vet.RegistroAtivo = true;
            _database.Veterinarios.Add(vet);
            _database.SaveChanges();
            Response.StatusCode = 201;
            return new ObjectResult(new{info = "Veterinário adicionado com sucesso"});
        }

        [HttpPatch("Atualizar")]
        public IActionResult AtualizarVet([FromBody] Veterinario vet){

            if (vet.Id != 0){

                var vetPatch = _database.Veterinarios.First(atualizaVet => atualizaVet.Id == vet.Id);

                if(vetPatch != null){

                    vetPatch.Nome = vet.Nome != null ? vet.Nome : vetPatch.Nome;
                    vetPatch.DocIdentificacao = vet.DocIdentificacao != null ? vet.DocIdentificacao : vetPatch.DocIdentificacao;
                    vetPatch.Email = vet.Email != null ? vet.Email : vetPatch.Email;
                    vetPatch.Senha = vet.Senha != null ? vet.Senha : vetPatch.Senha;
                    vetPatch.Especialidade = vet.Especialidade != null ? vet.Especialidade : vetPatch.Especialidade;
                    vetPatch.RegistroAtivo = vet.RegistroAtivo != false ? vet.RegistroAtivo : vetPatch.RegistroAtivo;
                    _database.SaveChanges();
                    return Ok("Veterinário atualizado com sucesso!");

                } else {

                    Response.StatusCode = 403;
                    return new ObjectResult(new {info = "Veterinário não encontrado!"});
                }
            }
                Response.StatusCode = 403;
                return new ObjectResult(new {info = "Veterinário não encontrado!"});
        }

        [HttpDelete("Excluir/{Id}")]
        public IActionResult DeletarVet(int Id){

            Veterinario vet = _database.Veterinarios.First(v => v.Id == Id);

            vet.RegistroAtivo = false;
            _database.SaveChanges();
            return Ok("Registro de veterinário excluído com sucesso!");
        }
    }
}