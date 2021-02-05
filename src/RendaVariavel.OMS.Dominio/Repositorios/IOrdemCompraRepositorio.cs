using System.Threading.Tasks;
using RendaVariavel.OMS.Dominio.Entidades;
using RendaVariavel.OMS.Dominio.Entidades.OrdemCompras;

namespace RendaVariavel.OMS.Dominio.Repositorios
{
    public interface IOrdemCompraRepositorio
    {
        Task<string> RegistrarOrdemCompra(OrdemCompra ordemCompra);
        Task<bool> AlterarOrdemCompra(string ordemId, OrdemCompraStatus novoOrdemCompraStatus);
        Task<string> ConsultarPorId(string id);
    }
}