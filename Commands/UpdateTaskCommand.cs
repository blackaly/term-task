using Repository;
using Models;

namespace Commands
{
    public class UpdateTaskCommand : ICommand
    {
        private readonly TaskHandler _taskHandler;
        private readonly Guid _taskId;
        private readonly string _newDescription;

        public UpdateTaskCommand(TaskHandler taskHandler, Guid taskId, string newDescription)
        {
            _taskHandler = taskHandler;
            _taskId = taskId;
            _newDescription = newDescription;
        }

        public void Execute()
        {
            _taskHandler.Update(_taskId, _newDescription);
            Console.WriteLine("Task updated successfully");
        }
    }
}