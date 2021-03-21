using System;
using System.Diagnostics;
using System.Threading;

namespace PassLock.Handler.CommandLineHandler
{
    public class ProcessTimeout
    {
        private readonly Process process;
        private readonly int timeout;

        public ProcessTimeout(Process process, int timeout)
        {
            this.process = process;
            this.timeout = timeout;
        }

        public void Run()
        {
            Thread.Sleep(timeout);

            try
            {
                if (process.HasExited == false)
                {
                    process.Kill();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
