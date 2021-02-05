using System.Collections.Generic;
using System.Threading.Tasks;
using RendaVariavel.OMS.Aplicacao.DTOs;

namespace RendaVariavel.OMS.Aplicacao.Servicos
{
    public interface IProdutoServico
    {
        Task<ProdutoDTO> ConsultarPorId(int id);
        //Task<IEnumerable<ProdutoDTO>> Consultar();
    }
}
