using Repository;
using Models.Nums;
namespace Commands
{
    public class MarkDoneCommand : ICommand
    {
        private readonly TaskHandler _taskHandler;
        private readonly Guid _taskId;

        public MarkDoneCommand(TaskHandler taskHandler, Guid taskId)
        {
            _taskHandler = taskHandler;
            _taskId = taskId;
        }

        public void Execute()
        {
            _taskHandler.UpdateStatus(_taskId, UTaskStatus.Complete);
            Console.WriteLine("Task marked as done");
        }
    }
}