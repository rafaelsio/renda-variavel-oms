using RendaVariavel.OMS.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace RendaVariavel.OMS.WebApi
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : Controller
    {
        private readonly IClienteServico _clienteServico;

        public ClienteController(IClienteServico clienteServico)
        {
            _clienteServico = clienteServico;
        }

        [HttpGet]
        [Route("")] //esse metodo não faz sentido , pois irá trazer muitos registros
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientes = await _clienteServico.ConsultarTodosClientes();
                if (clientes == null)
                    return BadRequest();

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500,(new { message = ex }));
            }
        }
       

        [HttpGet]
        [Route("{idCliente}")] //colocaria authorization um token jwt para somente o cliente logado obter os dados dele
        public async Task<IActionResult> ConsultarPorId([FromRoute] int idCliente)
        {
            try
            {
                var clientes = await _clienteServico.ConsultarPorId(idCliente);
                if (clientes == null)
                    return NotFound();

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, (new { message = ex }));
            }
        }
    }
}
