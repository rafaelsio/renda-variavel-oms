using System;
using System.ComponentModel;

namespace RendaVariavel.OMS.Commum.Constantes
{
    public enum MensagemErro
    {
        [Description("Cliente não encontrado")]
        OMS_001,

        [Description("Produto não encontrado")]
        OMS_002,

        [Description("Cliente não possui conta corrente")]
        OMS_003,

        [Description("Ordem de compra não é valida")]
        OMS_010,

        [Description("Cliente não possui saldo na conta correte / margem")]
        OMS_011,

        [Description("Ordem de venda não atende valor de venda minimo do produto ")]
        OMS_012,

        [Description("Produto não possui estoque para ordem de compra")]
        OMS_013,

        [Description("Mercado Fechado devido ao feriado")]
        OMS_014,

        [Description("Mercado Fechado devido ao horario")]
        OMS_015,
    }
}
