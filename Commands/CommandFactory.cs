using Repository;
namespace Commands
{
    public class CommandFactory
    {
        private readonly TaskHandler _taskHandler;

        public CommandFactory(TaskHandler taskHandler)
        {
            _taskHandler = taskHandler;
        }

        public ICommand CreateCommand(string[] args)
        {
            if (args == null || args.Length == 0)
            throw new ArgumentException("No command provided");

            var commandType = args[1].ToLower();
            return commandType switch
            {
                "add" when args.Length > 1 => new AddTaskCommand(_taskHandler, args[2]),
                "list" => new ListTasksCommand(_taskHandler, args.Length > 2 ? args[2] : "all"),
                "delete" when args.Length > 2 => new DeleteTaskCommand(_taskHandler, Guid.Parse(args[2])),
                "update" when args.Length > 2 => new UpdateTaskCommand(_taskHandler, Guid.Parse(args[2]), args[2]),
                "mark-in-progress" when args.Length > 2 => new MarkInProgressCommand(_taskHandler, Guid.Parse(args[2])),
                "mark-done" when args.Length > 2 => new MarkDoneCommand(_taskHandler, Guid.Parse(args[2])),
                _ => throw new ArgumentException("Invalid command or missing arguments")
            };
        }
    }
}