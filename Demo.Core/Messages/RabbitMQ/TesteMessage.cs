using Framework.MessageBroker;
using Framework.MessageBroker.RabbitMQ;

namespace Demo.Core.Messages.RabbitMQ
{
    public class TesteMessage : BaseMessage
    {
        public string Campo { get; set; }
    }
}