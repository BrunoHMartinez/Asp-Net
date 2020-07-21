using Aula02AspNet.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula02AspNet.DAL
{
    public class ViaCepDAO
    {
        private readonly Context _context;
        public ViaCepDAO(Context context)
        {
            _context = context;
        }
        public void Cadastrar(ViaCep cep)
        {
            _context.ceps.Add(cep);
            _context.SaveChanges();
        }

        public void Put(int id, [FromBody] ViaCep viaCep)
        {
            var cep = _context.ceps.FirstOrDefault(x => x.CepId == id);

             if (cep != null)
            {
                 cep.Logradouro = viaCep.Logradouro;
                 cep.Complemento = viaCep.Complemento;
                 cep.Bairro = viaCep.Bairro;
                 cep.Localidade = viaCep.Localidade;
                 cep.Uf = viaCep.Uf;
                _context.ceps.Update(cep);
                _context.SaveChanges();
            }
        }
public List<ViaCep> Listar()
        {
            return _context.ceps.ToList();
        }
        public ViaCep BuscarPorId(int CepId)
        {
            return _context.ceps.Find(CepId);
        }

        public IActionResult GetResult(int id)
        {
            var item = _context.ceps.Find(id);
                return new ObjectResult(item);
 
        }

        public void Deletar (int id)
        {
            var cep = _context.ceps.FirstOrDefault(x => x.CepId == id);
            if (cep != null)
            {
                _context.ceps.Remove(cep);
                _context.SaveChanges();
            }
        }
    }
}
