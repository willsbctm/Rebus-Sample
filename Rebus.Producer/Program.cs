using Rebus.Activation;
using Rebus.Bus;
using Rebus.Config;
using Rebus.Contract;
using Rebus.Serialization.Json;
using System;
using System.Threading.Tasks;

namespace Rebus.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            using (var activator = new BuiltinHandlerActivator())
            {
                Configure.With(activator)
                    .Transport(t => t.UseAzureServiceBusAsOneWayClient("connectionstring"))
                    .Serialization(l => l.UseNewtonsoftJson(JsonInteroperabilityMode.PureJson))
                    .Start();

                var bus = activator.Bus;

                do
                {
                    Console.WriteLine("Enter message (or quit to exit)");
                    Console.Write("> ");
                    string value = Console.ReadLine();

                    if ("quit".Equals(value, StringComparison.OrdinalIgnoreCase))
                        break;

                    await bus.Advanced.Topics.Publish("topicoloko", new Mensagem { Nome = $"Producer diz: {value}" });
                }
                while (true);

                bus.Dispose();
            }
        }
    }
}
