using System;
using System.Threading.Tasks;
using RendaVariavel.OMS.Dominio.Entidades.OrdemCompras;

namespace RendaVariavel.OMS.Dominio.ServicosExternos
{
    public interface IBolsaServicoExterno
    {
        Task EfetivarOrdemCompra(OrdemCompra ordemCompra);
    }
}
