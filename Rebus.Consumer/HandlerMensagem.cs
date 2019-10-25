using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Rebus.Contract;
using Rebus.Handlers;
using Rebus.Retry.Simple;

namespace Rebus.Consumer
{
    public partial class Program
    {
        public class HandlerMensagem : IHandleMessages<Mensagem>, IHandleMessages<IFailed<Mensagem>>
        {
            private readonly ILogger<HandlerMensagem> logger;

            public HandlerMensagem(ILogger<HandlerMensagem> logger)
            {
                this.logger = logger;
            }
            public Task Handle(Mensagem message)
            {
                logger.LogInformation($"Recebido: {message.Nome}");
                return Task.CompletedTask;
            }
            public Task Handle(IFailed<Mensagem> erro)
            {
                logger.LogInformation($"Erro: {erro.Message.Nome}");
                return Task.CompletedTask;
            }
        }
    }
}
