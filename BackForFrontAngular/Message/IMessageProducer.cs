namespace BackForFrontAngular.Message
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
