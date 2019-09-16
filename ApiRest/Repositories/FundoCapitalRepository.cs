using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Models;

namespace ApiRest.Repositories
{
    public class FundoCapitalRepository : IFundocapitalRepository
    {
        private readonly List<FundoCapital> _storage;
        public FundoCapitalRepository()
        {
            _storage = new List<FundoCapital>();
        }
        public void Adicionar(FundoCapital fundo)
        {
            _storage.Add(fundo);
        }

        public void Alterar(FundoCapital fundo)
        {
            var index = _storage.FindIndex(0, 1, e => e.Id == fundo.Id);
            _storage[index] = fundo;
        }

        public IEnumerable<FundoCapital> ListarFundos()
        {
            return _storage;
        }

        public FundoCapital ObterPorId(Guid Id)
        {
            return _storage.FirstOrDefault(e => e.Id == Id);
        }

        public void RemoverFundo(FundoCapital fundo)
        {
            _storage.Remove(fundo);
        }
    }
}
