using System;
using System.Threading.Tasks;
using RendaVariavel.OMS.Aplicacao.DTOs;
using RendaVariavel.OMS.Aplicacao.Mapeadores;
using RendaVariavel.OMS.Commum;
using RendaVariavel.OMS.Commum.Constantes;
using RendaVariavel.OMS.Dominio;
using RendaVariavel.OMS.Dominio.Entidades;
using RendaVariavel.OMS.Dominio.Repositorios;
using RendaVariavel.OMS.Dominio.Servicos;

namespace RendaVariavel.OMS.Aplicacao.Servicos
{
    public class OrdemCompraServico : IOrdemCompraServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IOrdemCompraDominioServico _ordemCompraDominoServico;
        private readonly IContaCorrente _contaCorrenteRepositorio;

        public OrdemCompraServico(IClienteRepositorio clienteRepositorio,
                                  IProdutoRepositorio produtoRepositorio,
                                  IOrdemCompraRepositorio ordemCompraRepositorio,
                                  IContaCorrente contaCorrenteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            _produtoRepositorio = produtoRepositorio;
            _contaCorrenteRepositorio = contaCorrenteRepositorio;
        }

        public async Task<ResultadoBase<bool>> SolicitarRegistroOrdemCompra(OrdemCompraDTO ordemCompraDTO)
        {
            var novaOrdemCompra = ordemCompraDTO.Mapear();

            if (!novaOrdemCompra.Valida())
                return new ResultadoBase<bool>() { CodigoErro = MensagemErro.OMS_010, Resultado = false, TipoErro= TipoErro.Validacao };

            var cliente = await _clienteRepositorio.ConsultarPorId(novaOrdemCompra.IdCliente);
            if(cliente == null)
                return new ResultadoBase<bool>() { CodigoErro = MensagemErro.OMS_001, Resultado = false, TipoErro = TipoErro.Validacao };

            var produto = await _produtoRepositorio.ConsultarPorId(novaOrdemCompra.IdProduto);
            if(produto == null)
                return new ResultadoBase<bool>() { CodigoErro = MensagemErro.OMS_002, Resultado = false, TipoErro = TipoErro.Validacao };

            var contaCorrente = await _contaCorrenteRepositorio.ObterPorId(novaOrdemCompra.IdCliente);
            if(contaCorrente == null)
                return new ResultadoBase<bool>() { CodigoErro = MensagemErro.OMS_003, Resultado = false, TipoErro = TipoErro.Validacao };

            return await _ordemCompraDominoServico.EfetuarRegistroOrdemCompra(cliente, produto, contaCorrente, novaOrdemCompra);
        }
    }
}