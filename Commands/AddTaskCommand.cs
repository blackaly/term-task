using Repository;
using Models;
namespace Commands
{
    public class AddTaskCommand : ICommand
    {
        private readonly TaskHandler _taskHandler;
        private readonly string _description;

        public AddTaskCommand(TaskHandler taskHandler, string description)
        {
            _taskHandler = taskHandler;
            _description = description;
        }

        public void Execute()
        {
            var task = new UTask(Guid.NewGuid(), _description, Models.Nums.UTaskStatus.InComplete, DateTime.Now, DateTime.Now);
            _taskHandler.Add(task);
            Console.WriteLine($"Task added successfully (ID: {task.Id})");
        }
    }
}