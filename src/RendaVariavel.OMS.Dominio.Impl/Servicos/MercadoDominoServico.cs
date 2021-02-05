
using System;
using System.Threading.Tasks;
using RendaVariavel.OMS.Commum;
using RendaVariavel.OMS.Commum.Constantes;
using RendaVariavel.OMS.Commum.Helpers;
using RendaVariavel.OMS.Dominio.Entidades.OrdemCompras;
using RendaVariavel.OMS.Dominio.Servicos;

namespace RendaVariavel.OMS.Dominio.Impl.Servicos
{
    public class MercadoDominoServico : IMercadoDominioServico
    {
        public MercadoDominoServico()
        {
        }

        public async Task<ResultadoBase<bool>> PermiteEnvioOrdem(DateTime dataEnvio)
        {

            if (DateTimeHelper.Feriado(dataEnvio))
            {
                return new ResultadoBase<bool>() { Resultado=false, CodigoErro= MensagemErro.OMS_014 , TipoErro= TipoErro.Negocio };
            }

            if (
                (dataEnvio.Hour >= Geral.HORARIO_ABERTURA_MERCADO.Hours && dataEnvio.Minute >= Geral.HORARIO_ABERTURA_MERCADO.Minutes) &&
                (dataEnvio.Hour < Geral.HORARIO_FECHAMENTO_MERCADO.Hours && dataEnvio.Minute < Geral.HORARIO_FECHAMENTO_MERCADO.Minutes)
               )
            {
                return new ResultadoBase<bool>() { Resultado = true }; //permite envio de ordem
            }
            else
            {
                return new ResultadoBase<bool>() { Resultado = false, CodigoErro = MensagemErro.OMS_015, TipoErro = TipoErro.Negocio };
            }

            
        }
    }
}
