using System;
using RendaVariavel.OMS.Dominio.Entidades;

namespace RendaVariavel.OMS.Aplicacao.Mapeadores
{
    public static class OrdemCompra
    {
        public static RendaVariavel.OMS.Dominio.Entidades.OrdemCompras.OrdemCompra Mapear(this RendaVariavel.OMS.Aplicacao.DTOs.OrdemCompraDTO dto)
        {
            var ordemCompra = new Dominio.Entidades.OrdemCompras.OrdemCompra()
            {
                Id = dto.Id,
                IdCliente = dto.IdCliente,
                IdProduto = dto.IdProduto,
                DataOperacao = dto.DataOperacao,
                PrecoUnitario = dto.PrecoUnitario,
                QuantidadeSolicitada = dto.QuantidadeSolicitada,
            };
            ordemCompra.AdicionarOrdemStatus(dto.Status);
            return ordemCompra;
        }

        public static RendaVariavel.OMS.Aplicacao.DTOs.OrdemCompraDTO Mapear(this RendaVariavel.OMS.Dominio.Entidades.OrdemCompras.OrdemCompra entidade)
        {
            var ordemCompra = new RendaVariavel.OMS.Aplicacao.DTOs.OrdemCompraDTO
            {
                Id = entidade.Id,
                IdCliente = entidade.IdCliente,
                IdProduto = entidade.IdProduto,
                DataOperacao = entidade.DataOperacao,
                PrecoUnitario = entidade.PrecoUnitario,
                QuantidadeSolicitada = entidade.QuantidadeSolicitada,
                Status = Enum.GetName(typeof(OrdemCompraStatus), entidade.Status)
            };
            
            return ordemCompra;
        }
    }
}
