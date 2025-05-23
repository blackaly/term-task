using Repository;
using Models.Nums;
namespace Commands
{
    public class MarkInProgressCommand : ICommand
    {
        private readonly TaskHandler _taskHandler;
        private readonly Guid _taskId;

        public MarkInProgressCommand(TaskHandler taskHandler, Guid taskId)
        {
            _taskHandler = taskHandler;
            _taskId = taskId;
        }

        public void Execute()
        {
            _taskHandler.UpdateStatus(_taskId, UTaskStatus.InProgress);
            Console.WriteLine("Task marked as in progress");
        }
    }
}