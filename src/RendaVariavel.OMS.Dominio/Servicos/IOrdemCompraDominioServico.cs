using System.Threading.Tasks;
using RendaVariavel.OMS.Commum;
using RendaVariavel.OMS.Dominio.Entidades.OrdemCompras;
using RendaVariavel.OMS.Dominio.Entidades.Clientes;
using RendaVariavel.OMS.Dominio.Entidades.Produtos;

namespace RendaVariavel.OMS.Dominio.Servicos
{
    public interface IOrdemCompraDominioServico
    {
        Task<ResultadoBase<bool>> PermiteEnvioDeOrdemCompra(Cliente cliente, Produto produto, ContaCorrente contaCorrente, OrdemCompra novaOrdemcompra);
    } 
}
