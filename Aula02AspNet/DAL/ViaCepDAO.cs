using Aula02AspNet.Models;
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
        public List<ViaCep> Listar()
        {
            return _context.ceps.ToList();
        }
    }
}
