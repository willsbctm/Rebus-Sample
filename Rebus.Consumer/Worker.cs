using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rebus.Bus;

namespace Rebus.Consumer
{
    public class Worker : IHostedService
    {
        private readonly ILogger<Worker> logger;
        private readonly IBus bus;
        private const string Topico = "topicoloko";
        public Worker(ILogger<Worker> logger, IBus bus)
        {
            this.logger = logger;
            this.bus = bus;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation($"Inscrição no tópico: {Topico}");
            return bus.Advanced.Topics.Subscribe(Topico);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation($"Cancelamento da inscrição no tópico: {Topico}");
            return bus.Advanced.Topics.Unsubscribe(Topico);
        }
    }
}
