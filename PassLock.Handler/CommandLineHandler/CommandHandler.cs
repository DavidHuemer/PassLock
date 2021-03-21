using PassLock.Handler.CommandLineHandler.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PassLock.Handler.CommandLineHandler
{
    /// <summary>
    /// Handles the commands to the console
    /// </summary>
    public static class CommandHandler
    {
        /// <summary>
        /// Runs the command asynchronously
        /// </summary>
        /// <param name="command">The command that should run</param>
        /// <returns>The command output</returns>
        public static async Task<CommandResult> RunCommandAsync(string command, int? timeout = null)
        {
            try
            {
                return await RunAsync(command, timeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Runs the batch file asynchronously
        /// </summary>
        /// <param name="command">The command that should run</param>
        /// <returns>The command output</returns>
        public static async Task<CommandResult> RunBatchAsync(string path, int? timeout = null)
        {
            Console.WriteLine($"Run batch async: {path}");

            if (!File.Exists(path))
                throw new IOException($"The file {path} does not exist");

            path = EncapsulateString(path);

            try
            {
                return await RunAsync(path, timeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Runs the command/file asynchronously
        /// </summary>
        /// <param name="command">The command that should run</param>
        /// <returns>The command output</returns>
        private static Task<CommandResult> RunAsync(string command, int? timeout = null)
        {
            var tcs = new TaskCompletionSource<CommandResult>();
            var processInfo = GetProcessInfo(command);

            var process = new Process
            {
                StartInfo = processInfo,
                EnableRaisingEvents = true
            };

            process.Exited += (sender, args) =>
            {
                var result = CommandResultHandler.Convert(process);
                tcs.SetResult(result);
                process.Dispose();
            };

            process.OutputDataReceived += Output;

            if (timeout != null)
            {
                StartThread(process, (int)timeout);
            }

            process.Start();

            return tcs.Task;
        }

        private static void StartThread(Process process, int timeout)
        {
            ProcessTimeout pto = new ProcessTimeout(process, timeout);
            Thread t = new Thread(new ThreadStart(pto.Run));
            t.Start();
        }

        /// <summary>
        /// Prints the output
        /// </summary>
        /// <param name="sender">The command line</param>
        /// <param name="e">The data</param>
        private static void Output(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        /// <summary>
        /// Encapsulates a string with double quotes
        /// </summary>
        /// <param name="str">The string that should be modified</param>
        /// <returns>The modified string</returns>
        public static string EncapsulateString(string str)
        {
            return $@"""{str}""";
        }

        /// <summary>
        /// Returns the ProcessStartInfo
        /// </summary>
        /// <param name="command">The command that should be run</param>
        /// <returns>The created ProcessStartInfo</returns>
        private static ProcessStartInfo GetProcessInfo(string command)
        {
            return new ProcessStartInfo("cmd.exe", "/c " + command)
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                RedirectStandardError = true,
            };
        }
    }
}
