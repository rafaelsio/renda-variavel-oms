using System;
namespace RendaVariavel.OMS.Aplicacao.DTOs
{
    public class OrdemCompraDTO
    {
        public int Id { get; set; }
        public DateTime DataOperacao { get; set; }
        public int IdProduto { get; set; }
        public int IdCliente { get; set; }
        public int QuantidadeSolicitada { get; set; }
        public decimal PrecoUnitario { get; set; }
        public string Status { get; set; }
    }
}
