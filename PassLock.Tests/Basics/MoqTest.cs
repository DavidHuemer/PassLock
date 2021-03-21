using PassLock.Handler.CommandLineHandler.Data;
using System.Threading.Tasks;

namespace PassLock.Tests.Basics
{
    public class MoqTest : BaseTest
    {
        protected CommandResult CreateCommandResult(string output)
        {
            return new CommandResult(CommandStatus.Success, output);
        }

        protected Task<CommandResult> CreateCommandResultTaskFromOutput(string output)
        {
            return Task.FromResult(CreateCommandResult(output));
        }

        protected Task<CommandResult> CreateCommandResultTask(CommandResult commandResult)
        {
            return Task.FromResult(commandResult);
        }

        protected CommandResult GetTask(CommandResult value)
        {
            return value;
        }
    }
}
