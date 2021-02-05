using System;
namespace RendaVariavel.OMS.Dominio.Entidades.Clientes
{
    public class ContaCorrente
    {
        public ContaCorrente()
        {

        }

        public string Id { get; set; }
        public string IdCliente { get; set; }
        public decimal SaldoContaCorrente { get; set; }
        public decimal SaldoContaMargem { get; set; }

        
        public bool PossuiSaldoOperacao(decimal valor)
        {
            return (
                    (this.SaldoContaCorrente >= valor) ||
                    (this.SaldoContaMargem >= valor)
                );
        }

    }
}
