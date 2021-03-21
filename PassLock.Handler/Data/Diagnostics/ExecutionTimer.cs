using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PassLock.Handler.Data.Diagnostics
{
    public class ExecutionTimer
    {
        private readonly Stopwatch stopwatch;

        public ExecutionTimer(bool autoStart = false)
        {
            stopwatch = new Stopwatch();
            if (autoStart)
                stopwatch.Start();
        }

        public void StopAndWrite([CallerMemberName] string executionName = "")
        {
            stopwatch.Stop();
            if (executionName == null)
            {
                StackTrace stackTrace = new StackTrace();
                executionName = stackTrace.GetFrame(1).GetMethod().Name;
            }

            Console.WriteLine($"{executionName} Execution Time: {stopwatch.ElapsedMilliseconds}");
        }
    }
}
