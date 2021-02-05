using System.Collections.Generic;
using System.Threading.Tasks;
using RendaVariavel.OMS.Dominio.Entidades.Produtos;

namespace RendaVariavel.OMS.Dominio.Repositorios
{
    public interface IProdutoRepositorio
    {
        Task<Produto> ConsultarPorId(int id);
        Task<IEnumerable<Produto>> Consultar();
    }
}