using PassLock.Bitwarden.Exceptions;
using PassLock.Handler.CommandLineHandler;
using PassLock.Handler.CommandLineHandler.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassLock.Bitwarden.Handler.BitwardenCommandLine
{
    public static class BitwardenCLIHandler
    {
        private const string TIMEOUT_OUTPUT = "Timeout";
        private const string SESSION_ARGUMENT_MISSING_OUTPUT = "error: option `--session <session>' argument missing";

        public static async Task<CommandResult> RunCommandAsync(string command, int? timeout = null)
        {
            var result = await CommandHandler.RunCommandAsync(command, timeout);

            if (result.Status != CommandStatus.Success)
            {
                string trimmedOutput = result.Output.Trim();

                if (trimmedOutput == TIMEOUT_OUTPUT || trimmedOutput == SESSION_ARGUMENT_MISSING_OUTPUT)
                    throw new AuthException(trimmedOutput);

                throw new Exception();
            }

            return result;
        }

        public static async Task<CommandResult> RunCommandAsync(string command, TimeSpan timespan)
        {
            return await RunCommandAsync(command, (int)timespan.TotalMilliseconds);
        }
    }
}
