using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Producer
{
    class Program
    {
        const string ServiceBusConnectionString = "connectionstring";
        const string TopicName = "topicoloko";
        static ITopicClient topicClient;

        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            topicClient = new TopicClient(ServiceBusConnectionString, TopicName);

            await SendMessagesAsync();

            Console.ReadKey();

            await topicClient.CloseAsync();
        }

        static async Task SendMessagesAsync()
        {
            try
            {
                do
                {
                    Console.WriteLine("Enter message (or quit to exit)");
                    Console.Write("> ");
                    string value = Console.ReadLine();

                    if ("quit".Equals(value, StringComparison.OrdinalIgnoreCase))
                        break;

                    var messageBody = $"{{\"Nome\": \"{value}\"}}";

                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                    message.UserProperties.Add("rbs2-msg-id", Guid.NewGuid().ToString());
                    message.UserProperties.Add("rbs2-content-type", "application/json");
                    message.UserProperties.Add("rbs2-msg-type", "Rebus.Contract.Mensagem, Rebus.Contract");

                    Console.WriteLine($"Sending message: {messageBody}");

                    await topicClient.SendAsync(message);
                }
                while (true);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }
        }
    }
}
