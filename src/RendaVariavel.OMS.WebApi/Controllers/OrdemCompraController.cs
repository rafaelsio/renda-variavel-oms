using RendaVariavel.OMS.Aplicacao.DTOs;
using RendaVariavel.OMS.Aplicacao.Servicos;
using RendaVariavel.OMS.Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace RendaVariavel.OMS.WebApi
{
    [ApiController]
    [Route("ordemcompra")]
    public class OrdemCompraController : Controller
    {
        private readonly IOrdemCompraServico _ordemCompraServico;
        
        public OrdemCompraController(IOrdemCompraServico ordemCompraServico, IOrdemCompraRepositorio ordemCompraRepositorio)
        {
            _ordemCompraServico = ordemCompraServico;
        }

        [HttpGet]
        [Route("{idOrdemCompra}")]
        public async Task<IActionResult> ConsultarPorId([FromRoute] string idOrdemCompra)
        {
            try
            {
                var result = await _ordemCompraServico.ConsultarPorId(idOrdemCompra);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, (new { message = ex }));
            }
        }

        [HttpPost]
        public async Task<IActionResult> SolicitarRegistroOrdemCompra([FromBody] OrdemCompraDTO ordemCompra)
        {
            try
            {
                var result = await _ordemCompraServico.SolicitarRegistroOrdemCompra(ordemCompra);
                if(result.Resultado == false)
                    return BadRequest(new { message = result.Descricao(), erro=result.CodigoErro });

                return Created(string.Empty, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, (new { message = ex }));
            }
        }
    }
}
