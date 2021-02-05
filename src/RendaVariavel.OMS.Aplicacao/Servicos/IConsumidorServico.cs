using System;
using System.Threading.Tasks;

namespace RendaVariavel.OMS.Aplicacao.Servicos
{
    public interface IConsumidorServico
    {
        Task ProcessarSolicitacoesOrdemCompra();

        Task ProcessarAtualizacoesOrdemCompra();

        Task ProcessarEnvioDeOrdensParaBolsa();
    }
}
