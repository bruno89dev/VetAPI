using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using GftPetCare.Data;
using GftPetCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GftPetCare.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class LoginsController : ControllerBase
    {
        private readonly ApplicationDbContext _database;

        public LoginsController(ApplicationDbContext database){
            _database = database;
        }

        [HttpPost("Login")]
        public IActionResult LoginUsuario(string Email, string Senha, bool usuarioVet){
            try {
                if(usuarioVet != true){
                    Cliente clienteLogin = _database.Clientes.First(cLogin => cLogin.Email.Equals(Email) && cLogin.Senha.Equals(Senha));
                    if (clienteLogin != null){

                        string chaveDeSeguranca = "xQ%7[K>z:FbzFTJa";
                        var chaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveDeSeguranca));
                        var credencialDeAcesso = new SigningCredentials(chaveSimetrica, SecurityAlgorithms.HmacSha256);

                        var claims = new List<Claim>();
                        claims.Add(new Claim("id", clienteLogin.Id.ToString()));
                        claims.Add(new Claim("email", clienteLogin.Email));
                        claims.Add(new Claim(ClaimTypes.Role, "userCliente"));

                        var jwt = new JwtSecurityToken(
                            issuer: "GftPetCare",
                            expires: DateTime.Now.AddHours(6),
                            audience: "usuarioLogado",
                            signingCredentials: credencialDeAcesso,
                            claims: claims
                        );
                        return Ok(new{ info = "Login realizado com sucesso!", token = new JwtSecurityTokenHandler().WriteToken(jwt)});

                    } else {

                        Response.StatusCode = 401;
                        return new ObjectResult(new{ info = "Credenciais não conferem. Acesso negado!"});
                    }
                
                } else {
                    Veterinario vetLogin = _database.Veterinarios.First(vLogin => vLogin.Email.Equals(Email) && vLogin.Senha.Equals(Senha));
                        if (vetLogin != null){

                            string chaveDeSeguranca = "xQ%7[K>z:FbzFTJa";
                            var chaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveDeSeguranca));
                            var credencialDeAcesso = new SigningCredentials(chaveSimetrica, SecurityAlgorithms.HmacSha256);

                            var claims = new List<Claim>();
                            claims.Add(new Claim("id", vetLogin.Id.ToString()));
                            claims.Add(new Claim("email", vetLogin.Email));
                            claims.Add(new Claim(ClaimTypes.Role, "userVet"));

                            var jwt = new JwtSecurityToken(
                                issuer: "GftPetCare",
                                expires: DateTime.Now.AddHours(6),
                                audience: "usuarioLogado",
                                signingCredentials: credencialDeAcesso,
                                claims: claims
                            );
                            return Ok(new{ info = "Login realizado com sucesso!", token = new JwtSecurityTokenHandler().WriteToken(jwt)});

                        } else {

                            Response.StatusCode = 401;
                            return new ObjectResult(new{ info = "Credenciais não conferem. Acesso negado!"});
                        }
                }

            }catch (Exception) {
                Response.StatusCode = 401;
                return new ObjectResult(new{ info = "Credenciais não conferem. Acesso negado!"});
            }
        }
    }
}