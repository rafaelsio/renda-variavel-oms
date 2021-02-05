using RendaVariavel.OMS.Dominio.Entidades.Clientes;


namespace RendaVariavel.OMS.Dominio.Agregados.Clientes
{
    public class ClienteContaCorrente
    {
        private readonly Cliente _cliente;
        private readonly ContaCorrente _contaCorrente;

        public ClienteContaCorrente(Cliente cliente, ContaCorrente contaCorrente)
        {
            this._cliente = cliente;
            this._contaCorrente = contaCorrente;
        }

        public Cliente Cliente { get; }
        public ContaCorrente ContaCorrente { get; }
    }
}
