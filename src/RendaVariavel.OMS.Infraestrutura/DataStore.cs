
using System.Collections.Generic;
using System.Linq;
using Bogus;
using RendaVariavel.OMS.Dominio;
using RendaVariavel.OMS.Dominio.Entidades.Clientes;
using RendaVariavel.OMS.Dominio.Entidades.OrdemCompras;
using RendaVariavel.OMS.Dominio.Entidades.Produtos;

namespace RendaVariavel.OMS.Infraestrutura
{
    public class DataStore
    {
        public List<OrdemCompra> OrdensCompras { get; set; } = new List<OrdemCompra>();

        public List<Cliente> Clientes { get; set; }
        public List<Produto> Produtos { get; set; }

        public DataStore()
        {
            LoadFakeData();
        }

        private void LoadFakeData()
        {
            Clientes = new Faker<Cliente>()
                .RuleFor(s => s.Id, f => f.UniqueIndex.ToString())
                .RuleFor(s => s.Nome, f => f.Name.FullName())
                .RuleFor(s => s.Endereco, f => f.Address.FullAddress())
                .Generate(10)
                .ToList();

            Clientes = new Faker<Cliente>()
                .RuleFor(s => s.Id, f => f.UniqueIndex.ToString())
                .RuleFor(s => s.Nome, f => f.Name.FullName())
                .RuleFor(s => s.Endereco, f => f.Address.FullAddress())
                .Generate(10)
                .ToList();

            Produtos = new Faker<Produto>()
                .RuleFor(s => s.Id, f => f.UniqueIndex)
                .RuleFor(s => s.Descricao, f => f.Commerce.ProductName())
                .RuleFor(s => s.Estoque, 1000)
                .RuleFor(s => s.ValorMinimoDeCompra, 500)
                .RuleFor(s => s.PrecoUnitario, f => f.Commerce.Price(1, 100, 2))
                .Generate(5)
                .ToList();
        }
    }
}