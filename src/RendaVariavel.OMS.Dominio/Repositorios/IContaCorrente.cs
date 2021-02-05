using System;
using System.Threading.Tasks;
using RendaVariavel.OMS.Dominio.Entidades.Clientes;

namespace RendaVariavel.OMS.Dominio.Repositorios
{
    public interface IContaCorrente
    {
        Task<ContaCorrente> ObterPorId(int idCliente);
    }
}
