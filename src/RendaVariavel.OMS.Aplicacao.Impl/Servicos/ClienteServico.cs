using System.Collections.Generic;
using System.Threading.Tasks;
using RendaVariavel.OMS.Aplicacao.DTOs;
using RendaVariavel.OMS.Dominio.Repositorios;

namespace RendaVariavel.OMS.Aplicacao.Servicos
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;

        }

        public async Task<ClienteDTO> ConsultarPorId(int idCliente)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ClienteDTO>> ConsultarTodosClientes()
        {
            throw new System.NotImplementedException();
        }
    }
}
