using System.Collections.Generic;
using System.Threading.Tasks;
using RendaVariavel.OMS.Dominio.Entidades.Clientes;

namespace RendaVariavel.OMS.Dominio.Repositorios
{
    public interface IClienteRepositorio
    {
        Task<Cliente> ConsultarPorId(int id);
        Task<IEnumerable<Cliente>> ConsultarTodosCliente();
    }
}