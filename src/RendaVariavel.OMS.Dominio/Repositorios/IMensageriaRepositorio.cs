using System;
using System.Threading.Tasks;
using RendaVariavel.OMS.Dominio.Entidades.Mensageria;

namespace RendaVariavel.OMS.Dominio.Repositorios
{
    public interface IMensageriaRepositorio
    {
        public Task EnviarMensagem<T>(TopicosMensageria topico, T mensagem);

        public Task<T> ReceberMensagem<T>(TopicosMensageria topico);
        
    }
}
