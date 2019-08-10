using System;
using System.IO;
using System.Text;

namespace XmlDemo.Common.Helpers
{
    public class FileHelper : IDisposable
    {
        private readonly string _path;
        private readonly Encoding _encoding;



        public FileHelper(string path) 
            : this(path, Encoding.UTF8)
        { }

        public FileHelper(string path, Encoding encoding)
        {
            _path = path;
            _encoding = encoding;
        }
        


        public void WriteStringToFile(string inputString)
        {
            try
            {
                TryWriteStringToFile(inputString);
            }
            catch (Exception e)
            {
                CatchWriteStringToFile(e);
                throw;
            }
        }

        private void TryWriteStringToFile(string inputString)
        {
            File.WriteAllText(_path, inputString, _encoding);
        }

        private static void CatchWriteStringToFile(Exception e)
        {
            ExceptionHelper.WriteExceptionToConsole(e, "Ett fel inträffade när strängen skulle skrivas till fil");
        }



        public string ReadStringFromFile()
        {
            try
            {
                return TryReadStringFromFile();
            }
            catch (Exception e)
            {
                CatchReadStringFromFile(e);
                throw;
            }
        }

        private string TryReadStringFromFile()
        {
            return File.ReadAllText(_path, _encoding);
        }

        private void CatchReadStringFromFile(Exception e)
        {
            ExceptionHelper.WriteExceptionToConsole(e, "Ett fel inträffade när strängen skulle läsas från fil");
        }

        public void Dispose()
        {
        }
    }
}
