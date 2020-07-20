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

        // Get: /api/Endereco/ListarEderecos 
        [HttpGet]
        [Route ("ListarEnderecos")]
        public List<ViaCep> Listar()
        {
            return _viaCepDAO.Listar(); 
        }
    }
}
