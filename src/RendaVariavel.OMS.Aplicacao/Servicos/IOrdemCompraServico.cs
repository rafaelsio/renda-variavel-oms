using System.Threading.Tasks;
using RendaVariavel.OMS.Aplicacao.DTOs;
using RendaVariavel.OMS.Commum;

namespace RendaVariavel.OMS.Aplicacao.Servicos
{
    public interface IOrdemCompraServico
    {
        //Task<ResultadoBase<bool>> AlterarStatudOrdemDeCompraParaEmAnalise(string ordemDeCompraId);
        Task<ResultadoBase<bool>> SolicitarRegistroOrdemCompra(OrdemCompraDTO ordemCompra);
    }
}