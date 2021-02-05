using System;

namespace RendaVariavel.OMS.Dominio.Entidades.OrdemCompras
{
    public class OrdemCompra
    {
        public OrdemCompra()
        {
            Status = OrdemCompraStatus.Solicitado;
        }

        public int Id { get; set; }
        public DateTime DataOperacao { get; set; }
        public int IdProduto { get; set; }
        public int IdCliente { get; set; }
        public int QuantidadeSolicitada { get; set; }
        public decimal PrecoUnitario { get; set; }
        public OrdemCompraStatus Status { get; set; }

        public decimal ValorOperacao()
        {
            return Math.Round(this.PrecoUnitario * this.QuantidadeSolicitada, 2);
        }

        public bool Valida()
        {
            return IdProduto != int.MinValue && IdCliente != int.MinValue && QuantidadeSolicitada >0 && PrecoUnitario >0;
        }
        

        public void AdicionarOrdemStatus(string status)
        {
            switch (status)
            {
                case "Solicitado":
                    this.Status = OrdemCompraStatus.Solicitado;
                    break;
                case "EmAnalise":
                    this.Status = OrdemCompraStatus.EmAnalise;
                    break;
                case "Fechado":
                    this.Status = OrdemCompraStatus.Solicitado;
                    break;
                case "Cancelado":
                    this.Status = OrdemCompraStatus.Solicitado;
                    break;
            }
        }
    }
}