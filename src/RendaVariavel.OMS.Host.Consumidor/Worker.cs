using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RendaVariavel.OMS.Aplicacao.Servicos;
using RendaVariavel.OMS.Dominio.Entidades.OrdemCompras;
using RendaVariavel.OMS.Dominio.Repositorios;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RendaVariavel.OMS.Host.Consumidor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConsumidorServico _consumidorServico;
        public Worker(
            ILogger<Worker> logger,
            IConsumidorServico consumidorServico
        )
        {
            _logger = logger;
            _consumidorServico = consumidorServico;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _consumidorServico.ProcessarAtualizacoesOrdemCompra();
                _consumidorServico.ProcessarSolicitacoesOrdemCompra();
                _consumidorServico.ProcessarEnvioDeOrdensParaBolsa();
            }
            catch(Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
            }
        }
    }
}
