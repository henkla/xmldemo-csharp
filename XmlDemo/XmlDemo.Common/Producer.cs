using System;
using System.Text;
using XmlDemo.Common.Helpers;

namespace XmlDemo.Common
{
    public class Producer<T> : ISender<T>, IDisposable
    {
        public void Send(T obj)
        {
            try
            {
                TrySend(obj);
            }
            catch (Exception e)
            {
                CatchSend(e);
                throw;
            }
        }

        private void TrySend(T obj)
        {
            using (var fileHelper = new FileHelper(Constants.PATH_TO_FILE, Encoding.UTF8))
            {
                var xmlAsString = XmlHelper.SerializeObject(obj);
                fileHelper.WriteStringToFile(xmlAsString);
            }
        }

        private static void CatchSend(Exception e)
        {
            ExceptionHelper.WriteExceptionToConsole(e, "Ett fel inträffade när XML-meddelandet skulle skickas");
        }

        public void Dispose()
        {
        }
    }
}
