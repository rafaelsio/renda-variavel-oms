using System;
using RendaVariavel.OMS.Commum.Constantes;

namespace RendaVariavel.OMS.Commum
{
    public class ResultadoBase<T>
    {
        public MensagemErro CodigoErro { get; set; }

        public TipoErro TipoErro {get; set;}

        public T Resultado { get; set; }

        public bool Valido()
        {
            return Enum.IsDefined(typeof(MensagemErro), CodigoErro);
        }

        public string Descricao()
        {
            return Enum.GetName(typeof(MensagemErro), CodigoErro);
        }
    }
}
