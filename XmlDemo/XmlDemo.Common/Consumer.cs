using System;
using System.Text;
using XmlDemo.Common.Helpers;

namespace XmlDemo.Common
{
    public class Consumer<T> : IReceiver<T>, IDisposable
    {
        public T Receive()
        {
            try
            {
                return TryReceive();
            }
            catch (Exception e)
            {
                CatchReceive(e);
                throw;
            }
        }

        private T TryReceive()
        {
            using (var fileHelper = new FileHelper(Constants.PATH_TO_FILE, Encoding.UTF8))
            {
                var xmlAsString = fileHelper.ReadStringFromFile();
                return XmlHelper.DeserializeXmlString<T>(xmlAsString);
            }
        }

        private static void CatchReceive(Exception e)
        {
            ExceptionHelper.WriteExceptionToConsole(e, "Ett fel inträffade när XML-meddelandet skulle tas emot");
        }

        public void Dispose()
        {
        }
    }
}
