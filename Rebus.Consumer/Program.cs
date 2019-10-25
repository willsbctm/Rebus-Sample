using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rebus.Config;
using Rebus.Contract;
using Rebus.Retry.Simple;
using Rebus.Serialization.Json;
using Rebus.ServiceProvider;

namespace Rebus.Consumer
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
                    services.AutoRegisterHandlersFromAssemblyOf<HandlerMensagem>();
                    services.AddTransient<Mensagem>();
                    services.AddRebus((configure, provider) =>
                    configure
                        .Logging(l => l.MicrosoftExtensionsLogging(loggerFactory))
                        .Transport(t => t.UseAzureServiceBus("connectionstring", "rebus-consumer"))
                        .Options(o => o.SimpleRetryStrategy(errorQueueAddress: "topicolokoerro", maxDeliveryAttempts: 3, secondLevelRetriesEnabled: true))
                        .Serialization(s => s.UseNewtonsoftJson(JsonInteroperabilityMode.PureJson))
                    );

                    services.AddHostedService<Worker>();
                });
    }
}
