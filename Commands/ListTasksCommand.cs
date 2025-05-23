using Repository;
using Models.Nums;

namespace Commands
{
    public class ListTasksCommand : ICommand
    {
        private readonly TaskHandler _taskHandler;
        private readonly string _statusStr;

        public ListTasksCommand(TaskHandler taskHandler, string status)
        {
            _taskHandler = taskHandler;
            _statusStr = status.ToLower();
        }

        public void Execute()
        {
            if (_statusStr == "all")
            {
                _taskHandler.ListTasks();
                return;
            }

            UTaskStatus status = _statusStr switch
            {
                "todo" => UTaskStatus.InComplete,
                "in-progress" => UTaskStatus.InProgress,
                "done" => UTaskStatus.Complete,
                _ => throw new ArgumentException("Invalid status. Use: todo, in-progress, or done")
            };

            var value = _taskHandler.GetTasksByStatus(status);
            if (value.Count == 0)
            {
                Console.WriteLine($"No tasks found with status: {_statusStr}");
            }
            else
            {
                foreach (var task in value)
                {
                    Console.WriteLine($"ID: {task.Id}, Description: {task.Description}, Status: {task.UTaskStatus}");
                }
            }
        }
    }
}