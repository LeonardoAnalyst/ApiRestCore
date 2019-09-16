using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Models;
using ApiRest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    public class FundoCapitalController : Controller
    {

        private readonly IFundocapitalRepository _repository;

        public FundoCapitalController(IFundocapitalRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("v1/fundocapital")]
        public IActionResult ListarFundos()
        {
            return Ok(_repository.ListarFundos());
        }

        [HttpPost("v1/fundocapital")]
        public IActionResult AdicionarFundo([FromBody]FundoCapital fundo)
        {
            _repository.Adicionar(fundo);
            return Ok();
        }

        [HttpPut("v1/fundocapital/{id}")]
        public IActionResult AlterarFundo(Guid id, [FromBody] FundoCapital fundo)
        {
            var fundoAntigo = _repository.ObterPorId(id);
            if (fundoAntigo == null)
            {
                return NotFound();
            }
            fundoAntigo.Nome = fundo.Nome;
            fundoAntigo.ValorAtual = fundo.ValorAtual;
            fundoAntigo.ValorNecessario = fundo.ValorNecessario;
            fundoAntigo.DataResgate = fundo.DataResgate;
            _repository.Alterar(fundoAntigo);
            return Ok();
        }

        [HttpGet("v1/fundocapital/{id}")]
        public IActionResult ObterFundo(Guid id)
        {
            var fundoAntigo = _repository.ObterPorId(id);
            if (fundoAntigo == null)
            {
                return NotFound();
            }        
            return Ok(fundoAntigo);
        }

        [HttpDelete("v1/fundocapital/{id}")]
        public IActionResult RemoverFundo(Guid id)
        {
            var fundo = _repository.ObterPorId(id);
            if (fundo == null)
            {
                return NotFound();
            }
            _repository.RemoverFundo(fundo);
            return Ok();
        }
    }
}