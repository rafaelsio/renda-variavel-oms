using System;
using System.Threading.Tasks;
using RendaVariavel.OMS.Aplicacao.Servicos;
using RendaVariavel.OMS.Dominio.Entidades;
using RendaVariavel.OMS.Dominio.Entidades.OrdemCompras;
using RendaVariavel.OMS.Dominio.Repositorios;
using RendaVariavel.OMS.Dominio.ServicosExternos;

namespace RendaVariavel.OMS.Aplicacao.Impl.Servicos
{
    public class ConsumidorServico : IConsumidorServico
    {
        private readonly IMensageriaRepositorio _mensageria;
        private readonly IOrdemCompraRepositorio _orderCompraRepositorio;
        private readonly IBolsaServicoExterno _bolsa;
        public ConsumidorServico
            (
                IMensageriaRepositorio mensageria,
                IOrdemCompraRepositorio orderCompraRepositorio,
                IBolsaServicoExterno bolsa
            )
        {
            _mensageria = mensageria;
            _orderCompraRepositorio = orderCompraRepositorio;
            _bolsa = bolsa;
        }

        public async Task ProcessarEnvioDeOrdensParaBolsa()
        {
            while (true)
            {
                var ordemCompra = _mensageria.ReceberMensagem<OrdemCompra>(Dominio.Entidades.Mensageria.TopicosMensageria.EnvioOrdemParaBolsa);
                if(ordemCompra != null)
                {
                    await _bolsa.EfetivarOrdemCompra(ordemCompra);
                }
            }
        }

        public async Task ProcessarAtualizacoesOrdemCompra()
        {
            while (true)
            {
                var ordemCompra = _mensageria.ReceberMensagem<OrdemCompra>(Dominio.Entidades.Mensageria.TopicosMensageria.SolicitacaoEnvioOrdem);
                if (ordemCompra != null)
                {
                    await _orderCompraRepositorio.AlterarOrdemCompra(ordemCompra.Id, ordemCompra.Status);
                    if(ordemCompra.Status == OrdemCompraStatus.EmAnalise)
                    {
                        var ordemCompra = _mensageria.EnviarMensagem<OrdemCompra>(Dominio.Entidades.Mensageria.TopicosMensageria.EnvioOrdemParaBolsa, ordemCompra);
                    }
                }
            }
        }

        public async Task ProcessarSolicitacoesOrdemCompra()
        {
            while (true)
            {
                var ordemCompra = _mensageria.ReceberMensagem<OrdemCompra>(Dominio.Entidades.Mensageria.TopicosMensageria.SolicitacaoEnvioOrdem);
                if(ordemCompra!=null)
                {
                    await _orderCompraRepositorio.RegistrarOrdemCompra(ordemCompra);

                    if (ordemCompra.Status == OrdemCompraStatus.Solicitado)
                    {
                        ordemCompra.Status = OrdemCompraStatus.EmAnalise;
                        var ordemCompra = _mensageria.EnviarMensagem<OrdemCompra>(Dominio.Entidades.Mensageria.TopicosMensageria.AtualizacaoOrdemCompraStatus, ordemCompra);
                    }
                } 
            }
        }
    }
}
