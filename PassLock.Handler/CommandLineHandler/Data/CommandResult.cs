namespace PassLock.Handler.CommandLineHandler.Data
{
    /// <summary>
    /// Represents the result of an command
    /// </summary>
    public class CommandResult
    {
        public CommandStatus Status { get; set; }
        public string Output { get; set; }

        public CommandResult(CommandStatus status, string output)
        {
            Status = status;
            Output = output;
        }

        public override string ToString()
        {
            return $"{Status}: {Output}";
        }
    }
}
