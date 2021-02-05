using System;
using System.Collections.Generic;

namespace RendaVariavel.OMS.Commum.Constantes
{
    public static class Geral
    {
        public static TimeSpan HORARIO_FECHAMENTO_MERCADO = new TimeSpan(18, 0, 0);
        public static TimeSpan HORARIO_ABERTURA_MERCADO = new TimeSpan(10, 0, 0);

        public static readonly TimeSpan HORARIO_INICIO_LEILAO_ABERTURA = new TimeSpan(9, 45, 0);
        public static readonly TimeSpan HORARIO_INICIO_LEILAO_FECHAMENTO = new TimeSpan(17, 45, 0);
        public static readonly List<DayOfWeek> DIAS_FUNCIONAMENTO_MERCADO;
    }
}
