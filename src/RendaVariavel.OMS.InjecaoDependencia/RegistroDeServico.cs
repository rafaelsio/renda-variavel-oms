
using RendaVariavel.OMS.Aplicacao.Servicos;
using RendaVariavel.OMS.Dominio.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using RendaVariavel.OMS.Infraestrutura.SqlFake.Repositorios;
using RendaVariavel.OMS.Dominio.Servicos;
using RendaVariavel.OMS.Dominio.Impl.Servicos;

namespace RendaVariavel.OMS.InjecaoDepencia
{
    public  class RegistroDeServico
    {
        public static void Registrar(IServiceCollection services)
        {
            //respositorios
            services.AddSingleton<IClienteRepositorio, ClienteRepositorio>();
            services.AddSingleton<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddSingleton<IOrdemCompraRepositorio, OrdemCompraRepositorio>();


            //services
            services.AddSingleton<IOrdemCompraServico, OrdemCompraServico>();
            services.AddSingleton<IClienteServico, ClienteServico>();

            services.AddSingleton<IOrdemCompraDominioServico, OrdemCompraDominioServico>();
            services.AddSingleton<IMercadoDominioServico, MercadoDominioServico>();

        }
    }
}
