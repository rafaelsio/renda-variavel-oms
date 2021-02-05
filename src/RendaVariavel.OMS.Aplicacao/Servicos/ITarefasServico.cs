using System;
using System.Threading.Tasks;

namespace RendaVariavel.OMS.Aplicacao.Servicos
{
    public interface ITarefasServico
    {
        Task EnviarOrdensAgendadas();
    }
}
