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
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext _database;

        public ClientesController(ApplicationDbContext database){
            _database = database;
        }

        [Authorize(Roles = "userVet")]
        [HttpGet("Listar")]
        public IActionResult GetClientes(){

            var listaDeClientes = _database.Clientes.ToList();

            if (listaDeClientes.Count == 0){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum cliente encontrado!"});
            } else {
                return Ok(listaDeClientes);
            }
        }

        [Authorize(Roles = "userVet")]
        [HttpGet("PesquisaId/{Id}")]
        public IActionResult GetClientesPorId(int Id){

            var clientesPorId = _database.Clientes.Where(cId => cId.Id == Id);

            if (clientesPorId == null){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum cliente encontrado!"});
            } else {
                return Ok(clientesPorId);
            }
        }

        [Authorize(Roles = "userCliente, userVet")]
        [HttpGet("PesquisaCpf/{Cpf}")]
        public IActionResult GetClientePorDocId(string Cpf){

            var clientePorCpf = _database.Clientes.Where(cDoc => cDoc.Cpf == Cpf).ToList();

            if(clientePorCpf.Count == 0){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum cliente encontrado com o cpf pesquisado!"});
            } else {
                return Ok(clientePorCpf);
            }
        }

        [Authorize(Roles = "userVet")]
        [HttpGet("PesquisaNome/{Nome}")]
        public IActionResult GetClientesPorNome(string Nome){

            var clientesPorNome = _database.Clientes.Where(cNome => cNome.Nome.Contains(Nome));

            if (clientesPorNome == null){
                Response.StatusCode = 404;
                return new ObjectResult(new {info = "Nenhum cliente encontrado!"});
            } else {
                return Ok(clientesPorNome);
            }
        }

        [Authorize(Roles = "userVet")]
        [HttpPost("Cadastrar")]
        public IActionResult CadastrarCliente([FromBody] ClienteDTO clienteTemp){

            Cliente cliente = new Cliente();

            cliente.Nome = clienteTemp.Nome;
            cliente.Cpf = clienteTemp.Cpf;
            cliente.Email = clienteTemp.Email;
            cliente.Senha = clienteTemp.Senha;
            cliente.RegistroAtivo = true;
            _database.Clientes.Add(cliente);
            _database.SaveChanges();
            Response.StatusCode = 201;
            return new ObjectResult(new{info = "Cliente adicionado com sucesso"});
        }

        [Authorize(Roles = "userVet")]
        [HttpPatch("Atualizar")]
        public IActionResult AtualizarCliente([FromBody] Cliente cliente){

            if (cliente.Id != 0){

                var clientePatch = _database.Clientes.First(atualizaCliente => atualizaCliente.Id == cliente.Id);

                if(clientePatch != null){

                    clientePatch.Nome = cliente.Nome != null ? cliente.Nome : clientePatch.Nome;
                    clientePatch.Cpf = cliente.Cpf != null ? cliente.Cpf : clientePatch.Cpf;
                    clientePatch.Email = cliente.Email != null ? cliente.Email : clientePatch.Email;
                    clientePatch.Senha = cliente.Senha != null ? cliente.Senha : clientePatch.Senha;
                    clientePatch.RegistroAtivo = cliente.RegistroAtivo != false ? cliente.RegistroAtivo : clientePatch.RegistroAtivo;
                    _database.SaveChanges();
                    return Ok("Cliente atualizado com sucesso!");

                } else {

                    Response.StatusCode = 403;
                    return new ObjectResult(new {info = "Cliente não encontrado!"});
                }
            }
                Response.StatusCode = 403;
                return new ObjectResult(new {info = "Cliente não encontrado!"});
        }

        [Authorize(Roles = "userVet")]
        [HttpDelete("Excluir/{Id}")]
        public IActionResult DeletarCliente(int Id){

            Cliente cliente = _database.Clientes.First(c => c.Id == Id);

            cliente.RegistroAtivo = false;
            _database.SaveChanges();
            return Ok("Registro de cliente excluído com sucesso!");
        }
    }
}