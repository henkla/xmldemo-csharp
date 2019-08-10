namespace XmlDemo.Common
{
    public interface IReceiver<T>
    {
        T Receive();
    }
}
