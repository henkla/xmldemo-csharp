namespace XmlDemo.Common
{
    public interface ISender<T>
    {
        void Send(T message);
    }
}
