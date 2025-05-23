using Repository;
using Models;

namespace Commands
{
    public class DeleteTaskCommand : ICommand
    {
        private readonly TaskHandler _taskHandler;
        private readonly Guid _taskId;

        public DeleteTaskCommand(TaskHandler taskHandler, Guid taskId)
        {
            _taskHandler = taskHandler;
            _taskId = taskId;
        }

        public void Execute()
        {
            if (_taskHandler.Delete(_taskId))
            {
                Console.WriteLine("Task deleted successfully");
            }
            else
            {
                Console.WriteLine("Task not found");
            }
        }
    }
}