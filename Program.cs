using System;
using Repository;
using Commands;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            PrintUsage();
            return;
        }

        var taskHandler = new TaskHandler();
        var commandFactory = new CommandFactory(taskHandler);

        try
        {
            ICommand command = commandFactory.CreateCommand(args);
            command.Execute();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void PrintUsage()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("  task-cli add \"task description\"");
        Console.WriteLine("  task-cli list [all|todo|in-progress|done]");
        Console.WriteLine("  task-cli update <id> \"new description\"");
        Console.WriteLine("  task-cli delete <id>");
        Console.WriteLine("  task-cli mark-in-progress <id>");
        Console.WriteLine("  task-cli mark-done <id>");
    }
}