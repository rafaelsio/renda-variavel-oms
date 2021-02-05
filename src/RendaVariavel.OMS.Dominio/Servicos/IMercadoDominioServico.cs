using System;
using System.Threading.Tasks;
using RendaVariavel.OMS.Commum;
using RendaVariavel.OMS.Dominio.Entidades.OrdemCompras;

namespace RendaVariavel.OMS.Dominio.Servicos
{
    public interface IMercadoDominioServico
    {
        Task<ResultadoBase<bool>> PermiteEnvioOrdem(DateTime data);
    }
}
