using System;
using System.Linq;
using System.Collections.Generic;

namespace RendaVariavel.OMS.Commum.Helpers
{
    public static class DateTimeHelper
    {

        public static bool Feriado(DateTime date)
        {
            List < DateTime > feriados = new List<DateTime>();

            feriados.Add(new DateTime(1, 1, 1));//ano novo
            feriados.Add(new DateTime(1, 9, 7));//indepencia

            return feriados.Where(f => f.Day == date.Day && f.Month == date.Month).Any();
        }
    }
}
