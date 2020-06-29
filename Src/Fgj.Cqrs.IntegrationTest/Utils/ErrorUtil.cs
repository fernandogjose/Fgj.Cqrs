using System;

namespace Fgj.Cqrs.IntegrationTest.Utils
{
    public static class ErrorUtil
    {
        public static Exception GetError(Exception exception)
        {
            if (exception.StackTrace != null)
                return new Exception($"Message: {exception.Message} - StackTrace: {exception.StackTrace}");
            else
                return exception;
        }
    }
}
