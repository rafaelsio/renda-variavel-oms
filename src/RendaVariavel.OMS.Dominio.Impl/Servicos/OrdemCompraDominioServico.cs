using System;
using System.Threading.Tasks;
using RendaVariavel.OMS.Commum;
using RendaVariavel.OMS.Commum.Constantes;
using RendaVariavel.OMS.Dominio.Entidades.Produtos;
using RendaVariavel.OMS.Dominio.Entidades.OrdemCompras;
using RendaVariavel.OMS.Dominio.Entidades.Clientes;
using RendaVariavel.OMS.Dominio.Repositorios;
using RendaVariavel.OMS.Dominio.Servicos;
using RendaVariavel.OMS.Dominio.Entidades.Mensageria;

namespace RendaVariavel.OMS.Dominio.Impl.Servicos
{
    public class OrdemCompraDominioServico : IOrdemCompraDominioServico
    {
        private readonly IContaCorrente _contaCorrenteRepositorio;
        private readonly IOrdemCompraRepositorio _ordemCompraRepositorio;
        private readonly IMercadoDominioServico _mercadoDominioServico;
        private readonly IMensageriaRepositorio _mensageriaRepoSitorio;


        public OrdemCompraDominioServico(
            IContaCorrente contaCorrenteRepositorio,
            IOrdemCompraRepositorio ordemCompraRepositorio,
            IMercadoDominioServico mercadoDominioServico,
            IMensageriaRepositorio mensageriaRepoSitorio
            )
        {
            _contaCorrenteRepositorio = contaCorrenteRepositorio;
            _ordemCompraRepositorio = ordemCompraRepositorio;
            _mercadoDominioServico = mercadoDominioServico;
            _mensageriaRepoSitorio = mensageriaRepoSitorio;


        }

        public async Task<ResultadoBase<bool>> EfetuarRegistroOrdemCompra(Cliente cliente, Produto produto, ContaCorrente contaCorrente, OrdemCompra novaOrdemcompra)
        {
            if (!contaCorrente.PossuiSaldoOperacao(novaOrdemcompra.ValorOperacao()))
                return new ResultadoBase<bool>() { CodigoErro = MensagemErro.OMS_011, Resultado = false, TipoErro = TipoErro.Negocio };

            if (produto.PermiteValorOperacao(novaOrdemcompra.ValorOperacao()))
                return new ResultadoBase<bool>() { CodigoErro = MensagemErro.OMS_012, Resultado = false, TipoErro = TipoErro.Negocio };

            if(produto.PossuiEstoque(novaOrdemcompra.QuantidadeSolicitada))
                return new ResultadoBase<bool>() { CodigoErro = MensagemErro.OMS_013, Resultado = false, TipoErro = TipoErro.Negocio };

            //verifica se omercado está aberto para envio da ordem
            var resultado = await _mercadoDominioServico.PermiteEnvioOrdem(DateTime.Now);
            if (!resultado.Resultado)
            {
                novaOrdemcompra.Status = Entidades.OrdemCompraStatus.Agendado;
            }

            await _mensageriaRepoSitorio.EnviarMensagem<OrdemCompra>(TopicosMensageria.SolicitacaoEnvioOrdem, novaOrdemcompra);


            return new ResultadoBase<bool>() { Resultado = true };
        }
    }
}
