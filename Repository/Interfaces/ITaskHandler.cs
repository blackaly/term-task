using Models;
using Models.Nums;
namespace Repository.Interfaces;

public interface ITaskHandler
{
    bool Add(UTask task);
    bool Update(Guid guid, string des);
    bool UpdateStatus(Guid guid, UTaskStatus uTaskStatus);
    bool Delete(Guid guid);
    void ListTasks();
    List<UTask> GetTasksByStatus(UTaskStatus uTaskStatus);
}