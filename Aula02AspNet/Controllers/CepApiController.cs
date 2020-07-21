using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula02AspNet.DAL;
using Aula02AspNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula02AspNet.Controllers
{
    [Route("api/Endereco")]
    [ApiController]
    public class CepApiController : ControllerBase
    {
        private readonly ViaCepDAO _viaCepDAO;
        public CepApiController(ViaCepDAO viaCepDAO)
        {
            _viaCepDAO = viaCepDAO;
        }

        // Get: /api/Endereco/ListarEnderecos
        [HttpGet]
        [Route("ListarEnderecos")]
        public IActionResult Listar()
        {
            return Ok(_viaCepDAO.Listar());
        }

        // Post: /api/Endereco/CadastrarEndereco
        [HttpPost]
        [Route("CadastrarEndereco")]
        public IActionResult CadastrarEnderecos(ViaCep cep)
        {
            _viaCepDAO.Cadastrar(cep);
            return Created("", cep);
        }

        // Get :  /api/Endereco/ListarEndereco/{id}
        [HttpGet]
        [Route("ListarEndereco/{id}", Name = "id")]
        public IActionResult GetResult (int id)
        {
            return Ok(_viaCepDAO.GetResult(id));
        }
        // Put : /api/Endereco/AlterarEndereco
        [HttpPut]
        [Route("AlterarEndereco/{id}", Name = "Cepid")]
        public IActionResult Alterar (int id, ViaCep cep)
        {
            _viaCepDAO.Put(id, cep);
            return Created("", cep);
        }

        // Delete : /api/Endereco/DeletarEndereco
        [HttpDelete]
        [Route("DeletarEndereco/{id}", Name = "CepRId")]
        public IActionResult Deletar(int id)
        {
            _viaCepDAO.Deletar(id);
            return Ok();
           
        }
    }
}
