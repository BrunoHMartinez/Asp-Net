using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aula02AspNet.DAL;
using Aula02AspNet.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Aula02AspNet.Controllers
{
    public class CepController : Controller
    {
        private readonly ViaCepDAO _viaCepDAO;
        public CepController(ViaCepDAO viaCepDAO)
        {
            _viaCepDAO = viaCepDAO;
        }
        public IActionResult Index()
        {       
            if (TempData["Cep"] != null)
            {
                string resultado = TempData["Cep"].ToString();
                ViaCep cep = JsonConvert.DeserializeObject<ViaCep>(resultado);
                _viaCepDAO.Cadastrar(cep);
            }
            ViewBag.ceps = _viaCepDAO.Listar();
            return View();
        }

        [HttpPost]
        public IActionResult Pesquisar(string txtCep)
        {
            string url = $@"https://viacep.com.br/ws/{txtCep}/json/";
            WebClient client = new WebClient();
            TempData["Cep"] = client.DownloadString(url);
            return RedirectToAction("Index");
        }
    }
}
