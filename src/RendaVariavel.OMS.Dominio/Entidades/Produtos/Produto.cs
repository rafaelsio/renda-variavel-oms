namespace RendaVariavel.OMS.Dominio.Entidades.Produtos
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Estoque { get; set; }
        public string PrecoUnitario { get; set; }
        public int ValorMinimoDeCompra { get; set; }

        public bool PermiteValorOperacao(decimal valorOPeracao)
        {
            return valorOPeracao >= this.ValorMinimoDeCompra;
        }

        public bool PossuiEstoque(int qtdeSolicitada)
        {
            return this.Estoque >= qtdeSolicitada;
        }
    }
}