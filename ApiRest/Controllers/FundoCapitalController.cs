using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    public class FundoCapitalController : Controller
    {
        [HttpGet("v1/fundocapital")]
        public IActionResult ListarFundos()
        {
            return Ok(
                new List<FundoCapital>
                {
                    new FundoCapital
                    {
                        Nome = "Viagem de Ferias",
                        ValorAtual=200,
                        ValorNecessario=5000,
                        DataResgate = new DateTime(2019,12,1)
                    },
                      new FundoCapital
                    {
                        Nome = "Reserva de emergencia",
                        ValorAtual=400,
                        ValorNecessario=10000,
                    }
                });
        }

        [HttpPost("v1/fundocapital")]
        public IActionResult AdicionarFundo([FromBody]FundoCapital fundo)
        {
            return Ok();
        }

        [HttpPut("v1/fundocapital/{id}")]
        public IActionResult AlterarFundo(Guid id, [FromBody] FundoCapital fundo)
        {
            return Ok();
        }
    }
}