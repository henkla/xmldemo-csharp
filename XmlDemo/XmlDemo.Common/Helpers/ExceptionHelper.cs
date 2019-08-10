using System;

namespace XmlDemo.Common.Helpers
{
    public static class ExceptionHelper
    {
        public static void WriteExceptionToConsole(Exception e, string errorMessage)
        {
            if (string.IsNullOrEmpty(errorMessage))
            {
                errorMessage = Constants.DEFAULT_ERROR_MESSAGE;
            }

            Console.WriteLine(Constants.DEFAULT_ERROR_BANNER + errorMessage + ":");
            Console.WriteLine(Constants.DEFAULT_ERROR_BANNER + e.Message);

            if (ExceptionHasBaseMessage(e))
            {
                Console.WriteLine(Constants.DEFAULT_ERROR_BANNER + e);
            }
        }

        public static bool ExceptionHasBaseMessage(Exception e)
        {
            return e.GetBaseException() != null &&
                   e.GetBaseException() != e;
        }
    }
}
