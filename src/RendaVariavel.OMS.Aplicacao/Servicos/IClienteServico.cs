using System.Collections.Generic;
using System.Threading.Tasks;
using RendaVariavel.OMS.Aplicacao.DTOs;

namespace RendaVariavel.OMS.Aplicacao.Servicos
{
    public interface IClienteServico
    {
        Task<ClienteDTO> ConsultarPorId(int idCliente);
        //Task<IEnumerable<ClienteDTO>> ConsultarTodosClientes();
    }
}
