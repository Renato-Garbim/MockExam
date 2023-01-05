using System.Collections.Concurrent;

namespace BackForFrontAngular.Message
{
    public interface IMessageProducer
    {
        Task<string> SendMessageExchange<T>(T message);
    }
}
