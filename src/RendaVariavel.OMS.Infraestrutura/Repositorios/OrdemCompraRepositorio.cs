﻿using System;
using System.Threading.Tasks;
using RendaVariavel.OMS.Dominio.Entidades;
using RendaVariavel.OMS.Dominio.Entidades.OrdemCompras;
using RendaVariavel.OMS.Dominio.Repositorios;

namespace RendaVariavel.OMS.Infraestrutura.SqlFake.Repositorios
{
    public class OrdemCompraRepositorio : IOrdemCompraRepositorio
    {
        private readonly DataStore _dataStore;

        public OrdemCompraRepositorio(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public Task<bool> AlterarOrdemCompra(OrdemCompra ordemCompra)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AlterarOrdemCompra(string ordemId, OrdemCompraStatus novoOrdemCompraStatus)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ConsultarPorId(string id)
        {
            var ordemCompra = await Task.FromResult(_dataStore.OrdensCompras.Find(x => x.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase))).ConfigureAwait(false);
            return ordemCompra.Id;
        }

        public async Task<string> RegistrarOrdemCompra(OrdemCompra ordemCompra)
        {
            await Task.Run(() => _dataStore.OrdensCompras.Add(ordemCompra)).ConfigureAwait(false);
            return ordemCompra.Id;
        }
    }
}