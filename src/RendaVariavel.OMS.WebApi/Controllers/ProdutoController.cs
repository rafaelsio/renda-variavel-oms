using RendaVariavel.OMS.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DojoDDD.Api.Controllers
{
    [ApiController]
    [Route("produtos")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoServico _produtoServico;

        public ProdutoController(IProdutoServico produtoServico)
        {
            _produtoServico = produtoServico;
        }

        /*[HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientes = await = produtoServico.Consultar();
                if (clientes == null)
                    return NoContent();

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex });
            }
        }*/

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ConsutarPorId([FromRoute] int id)
        {
            try
            {
                var clientes = await _produtoServico.ConsultarPorId(id);
                if (clientes == null)
                    return NoContent();
                
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, (new { message = ex }));
            }
        }
    }
}
