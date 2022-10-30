using System;
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
    public class AtendimentosController : ControllerBase
    {
        private readonly ApplicationDbContext _database;

        public AtendimentosController(ApplicationDbContext database){
            _database = database;
        }

        [Authorize(Roles = "userVet")]
        [HttpGet("Listar")]
        public IActionResult GetAtendimentos(){

            var listaDeAtendimentos = _database.Atendimentos.Include(vet => vet.Veterinario).Include(animal => animal.Animal).Include(tutor => tutor.Tutor).ToList();
            
            if (listaDeAtendimentos.Count == 0){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum atendimento encontrado!"});
            } else {
                return Ok(listaDeAtendimentos);
            }
        }

        [Authorize(Roles = "userVet")]
        [HttpGet("{Id}")]
        public IActionResult GetAtendimentoPorId(int Id){

            var atendimentoPorId = _database.Atendimentos.Include(vet => vet.Veterinario).Include(animal => animal.Animal).Include(tutor => tutor.Tutor).First(a => a.Id == Id);

            if (atendimentoPorId.RegistroAtivo != true){
                Response.StatusCode = 404;
                return new ObjectResult(new { info = "Atendimento não encontrado!"});
            } else {
                return Ok(atendimentoPorId);
            }
        }

        [Authorize(Roles = "userVet")]
        [HttpGet("Animal/PesquisaId/{Id}")]
        public IActionResult GetAtendimentoPorAnimalId(int Id){
            
            var atendimentoPorAnimalId = _database.Atendimentos.Include(vet => vet.Veterinario).Include(animal => animal.Animal).Include(tutor => tutor.Tutor).Where(aId => aId.Animal.Id == Id).ToList();

            if(atendimentoPorAnimalId.Count == 0){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum atendimento encontrado com o animal pesquisado!"});
            } else {
                return Ok(atendimentoPorAnimalId);
            }
        }

        [Authorize(Roles = "userVet")]
        [HttpGet("Animal/PesquisaNome/{Nome}")]
        public IActionResult GetAtendimentoPorNomeAnimal(string Nome){
            
            var atendimentoPorNomeAnimal = _database.Atendimentos.Include(vet => vet.Veterinario).Include(animal => animal.Animal).Include(tutor => tutor.Tutor).Where(aNome => aNome.Animal.Nome.Contains(Nome)).ToList();

            if(atendimentoPorNomeAnimal.Count == 0){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum atendimento encontrado com o animal pesquisado!"});
            } else {
                return Ok(atendimentoPorNomeAnimal);
            }
        }

        [Authorize(Roles = "userVet")]
        [HttpGet("Animal/PesquisaRaca/{Raca}")]
        public IActionResult GetAtendimentoPorRaca(string Raca){
            
            var atendimentoPorRaca = _database.Atendimentos.Include(vet => vet.Veterinario).Include(animal => animal.Animal).Include(tutor => tutor.Tutor).Where(r => r.Animal.Raca.Contains(Raca)).ToList();

            if(atendimentoPorRaca.Count == 0){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum atendimento encontrado com a raça pesquisada!"});
            } else {
                return Ok(atendimentoPorRaca);
            }
        }

        [Authorize(Roles = "userCliente, userVet")]
        [HttpGet("Cliente/PesquisaCpf/{Cpf}")]
        public IActionResult GetAtendimentoPorClienteCpf(string Cpf){
            
            var atendimentoPorClienteCpf = _database.Atendimentos.Include(vet => vet.Veterinario).Include(animal => animal.Animal).Include(tutor => tutor.Tutor).Where(cId => cId.Tutor.Cpf == Cpf).ToList();

            if(atendimentoPorClienteCpf.Count == 0){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum atendimento encontrado com o cliente pesquisado!"});
            } else {
                return Ok(atendimentoPorClienteCpf);
            }
        }

        [Authorize(Roles = "userVet")]
        [HttpGet("Cliente/PesquisaId/{Id}")]
        public IActionResult GetAtendimentoPorClienteId(int Id){
            
            var atendimentoPorClienteId = _database.Atendimentos.Include(vet => vet.Veterinario).Include(animal => animal.Animal).Include(tutor => tutor.Tutor).Where(cId => cId.Tutor.Id == Id).ToList();

            if(atendimentoPorClienteId.Count == 0){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum atendimento encontrado com o cliente pesquisado!"});
            } else {
                return Ok(atendimentoPorClienteId);
            }
        }

        [Authorize(Roles = "userVet")]
        [HttpGet("Cliente/PesquisaNome/{Nome}")]
        public IActionResult GetAtendimentoPorNomeCliente(string Nome){
            
            var atendimentoPorNomeCliente = _database.Atendimentos.Include(vet => vet.Veterinario).Include(animal => animal.Animal).Include(tutor => tutor.Tutor).Where(cNome => cNome.Tutor.Nome.Contains(Nome)).ToList();

            if(atendimentoPorNomeCliente.Count == 0){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum atendimento encontrado com o cliente pesquisado!"});
            } else {
                return Ok(atendimentoPorNomeCliente);
            }
        }

        [Authorize(Roles = "userVet")]
        [HttpGet("Veterinario/PesquisaId/{Id}")]
        public IActionResult GetAtendimentoPorVetId(int Id){
            
            var atendimentoPorVetId = _database.Atendimentos.Include(vet => vet.Veterinario).Include(animal => animal.Animal).Include(tutor => tutor.Tutor).Where(vId => vId.Veterinario.Id == Id).ToList();

            if(atendimentoPorVetId.Count == 0){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum atendimento encontrado com o veterinário pesquisado!"});
            } else {
                return Ok(atendimentoPorVetId);
            }
        }
        
        [Authorize(Roles = "userVet")]
        [HttpGet("Veterinario/PesquisaNome/{Nome}")]
        public IActionResult GetAtendimentoPorNomeVet(string Nome){
            
            var atendimentoPorNomeVet = _database.Atendimentos.Include(vet => vet.Veterinario).Include(animal => animal.Animal).Include(tutor => tutor.Tutor).Where(vNome => vNome.Veterinario.Nome.Contains(Nome)).ToList();

            if(atendimentoPorNomeVet.Count == 0){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum atendimento encontrado com o veterinário pesquisado!"});
            } else {
                return Ok(atendimentoPorNomeVet);
            }
        }

        [Authorize(Roles = "userVet")]
        [HttpPost("Cadastrar")]
        public IActionResult CadastrarAtendimento([FromBody] AtendimentoDTO atendimentoTemp){

            Atendimento atendimento = new Atendimento();

            atendimento.DataDoAtendimento = atendimentoTemp.DataDoAtendimento;
            atendimento.Veterinario = _database.Veterinarios.First(vet => vet.Id == atendimentoTemp.VeterinarioId);
            atendimento.Animal = _database.Animais.First(animal => animal.Id == atendimentoTemp.AnimalId);
            atendimento.Tutor = _database.Clientes.First(tutor => tutor.Id == atendimentoTemp.TutorId);
            atendimento.PesoAtual = atendimentoTemp.PesoAtual;
            atendimento.AlturaEmCmAtual = atendimentoTemp.AlturaEmCmAtual;
            atendimento.Diagnostico = atendimentoTemp.Diagnostico;
            atendimento.ObservacoesGerais = atendimentoTemp.ObservacoesGerais;
            atendimento.RegistroAtivo = true;
            _database.Atendimentos.Add(atendimento);
            _database.SaveChanges();
            Response.StatusCode = 201;
            return new ObjectResult(new{info = "Atendimento adicionado com sucesso"});
        }

        [Authorize(Roles = "userVet")]
        [HttpPost("Finalizar/{Id}")]
        public IActionResult FinalizarAtendimento([FromRoute] int Id){

            var fimAtendimento = _database.Atendimentos.Include(animal => animal.Animal).Include(vet => vet.Veterinario).First(atendimento => atendimento.Id == Id);

            try { 
                if(fimAtendimento.IsFinalizado != false){
                    Response.StatusCode = 403;
                    return new ObjectResult(new {info = "Atendimento já finalizado!"});
                } else {
                    fimAtendimento.IsFinalizado = true;
                    _database.SaveChanges();
                    Response.StatusCode = 201;
                    return new ObjectResult(new {info = "Registro de atendimento finalizado com sucesso!"});
                }
            } catch (Exception){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum atendimento encontrado!"});
            }
        }

        [Authorize(Roles = "userVet")]
        [HttpPatch("Atualizar")]
        public IActionResult AtualizarVet([FromBody] Atendimento atendimento){

            if (atendimento.Id != 0){

                var atendPatch = _database.Atendimentos.First(atualizaAtend => atualizaAtend.Id == atendimento.Id);

                if(atendPatch != null){

                    atendPatch.DataDoAtendimento = atendimento.DataDoAtendimento != null ? atendimento.DataDoAtendimento : atendPatch.DataDoAtendimento;
                    atendPatch.Veterinario = atendimento.Veterinario != null ? atendimento.Veterinario : atendPatch.Veterinario;
                    atendPatch.Animal = atendimento.Animal != null ? atendimento.Animal : atendPatch.Animal;
                    atendPatch.PesoAtual = atendimento.PesoAtual != 0 ? atendimento.PesoAtual : atendPatch.PesoAtual;
                    atendPatch.AlturaEmCmAtual = atendimento.AlturaEmCmAtual != 0 ? atendimento.AlturaEmCmAtual : atendPatch.AlturaEmCmAtual;
                    atendPatch.Diagnostico = atendimento.Diagnostico != null ? atendimento.Diagnostico : atendPatch.Diagnostico;
                    atendPatch.ObservacoesGerais = atendimento.ObservacoesGerais != null ? atendimento.ObservacoesGerais : atendPatch.ObservacoesGerais;
                    atendPatch.RegistroAtivo = atendimento.RegistroAtivo != false ? atendimento.RegistroAtivo : atendPatch.RegistroAtivo;
                    _database.SaveChanges();
                    return Ok("Atendimento atualizado com sucesso!");

                } else {

                    Response.StatusCode = 404;
                    return new ObjectResult(new {info = "Atendimento não encontrado!"});
                }
            }
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Atendimento não encontrado!"});
        }

        [Authorize(Roles = "userVet")]
        [HttpDelete("Excluir/{Id}")]
        public IActionResult DeletarAtendimento([FromRoute] int Id){

            var deletaAtendimento = _database.Atendimentos.First(atendimento => atendimento.Id == Id);

            if(deletaAtendimento.Id == Id){
                _database.Atendimentos.Remove(deletaAtendimento);
                return Ok("Atendimento excluído com sucesso!");
            } else {
                Response.StatusCode = 403;
                return new ObjectResult(new {info = "Não foi possível excluir o atendimento solicitado. Registro já excluído / não existe!"});
            }
        }
    }
}