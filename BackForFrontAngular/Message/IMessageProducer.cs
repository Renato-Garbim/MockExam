using System.Collections.Concurrent;

namespace BackForFrontAngular.Message
{
    public interface IMessageProducer
    {
        BlockingCollection<string> SendMessageExchange<T>(T message);
    }
}
