
namespace RendaVariavel.OMS.Aplicacao.Mappers
{
    public static class Cliente
    {

        public static RendaVariavel.OMS.Dominio.Entidades.Clientes.Cliente Mapear(this RendaVariavel.OMS.Aplicacao.DTOs.ClienteDTO cliente)
        {
            return new Dominio.Entidades.Clientes.Cliente()
            {
                Endereco = cliente.Endereco,
                Id = cliente.Id,
                Idade = cliente.Idade,

            };
        }

        public static RendaVariavel.OMS.Aplicacao.DTOs.ClienteDTO Mapear(this RendaVariavel.OMS.Dominio.Entidades.Clientes.Cliente cliente)
        {
            return new DTOs.ClienteDTO()
            {
                Endereco = cliente.Endereco,
                Id = cliente.Id,
                Idade = cliente.Idade,
            };
        }
    }
}
