using PassLock.Handler.CommandLineHandler.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassLock.Handler.CommandLineHandler
{
    public class CommandResultHandler
    {
        public static CommandResult Convert(Process process)
        {
            if (!process.HasExited)
                throw new ArgumentException("The process must be exited");

            if (process.ExitCode == -1)
                return new CommandResult(CommandStatus.Error, "Timeout");

            string standartOut = process.StandardOutput.ReadToEnd();
            if (standartOut != "")
            {
                return new CommandResult(CommandStatus.Success, standartOut);
            }

            string errorOut = process.StandardError.ReadToEnd();

            if (errorOut != "")
            {
                return new CommandResult(CommandStatus.Error, errorOut);
            }
            else
            {
                return new CommandResult(CommandStatus.Unknown, "");
            }
        }
    }
}
