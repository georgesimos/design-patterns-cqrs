using System;
using System.Net.Sockets;
using System.Threading;

namespace DesignPatterns
{
    public static class RetryUtils
    {
        public static TRet RetryIfThrown<TException, TRet>(Func<TRet> action, int numberOfTries, int delayBetweenTries) where TException : Exception
        {
            TException lastException = null;

            for (var currentTry = 1; currentTry <= numberOfTries; currentTry++)
            {
                try
                {
                    //throw new ArgumentNullException();
                    return action();
                }
                catch (TException e)
                {
                    lastException = e;
                }

                Thread.Sleep(delayBetweenTries);
            }

            if (lastException != null)
                throw lastException;

            throw new Exception("No exception to rethrow");
        }
    }
}
