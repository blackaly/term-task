using Models;
using Validation;
using Repository.Interfaces;
using System.Text.Json;
using Models.Nums;

namespace Repository;

public class TaskHandler : ITaskHandler
{
    private readonly JsonSerializerOptions _jsonOptions;
    private string FILE_PATH = FileSystemValidation.FullPATH;

    public TaskHandler()
    {
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public bool Add(UTask task)
    {
        try
        {
            EnsureFileExists();
            var tasks = GetAllTasks();
            tasks.Add(task);
            SaveTasks(tasks);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Update(Guid guid, string description)
    {
        return UpdateTaskProperties(guid, task =>
        {
            task.Description = description;
            task.UpdatedAt = DateTime.Now;
        });
    }

    public bool UpdateStatus(Guid guid, UTaskStatus status)
    {
        return UpdateTaskProperties(guid, task => task.UTaskStatus = status);
    }

    public bool Delete(Guid guid)
    {
        try
        {
            var tasks = GetAllTasks();
            var taskToDelete = tasks.FirstOrDefault(x => x.Id == guid);
            if (taskToDelete == null) return false;

            tasks.Remove(taskToDelete);
            SaveTasks(tasks);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void ListTasks()
    {
        var tasks = GetAllTasks();
        foreach (var task in tasks)
        {
            PrintTask(task);
        }
    }

    public List<UTask> GetTasksByStatus(UTaskStatus status)
    {
        return GetAllTasks()
            .Where(x => x.UTaskStatus == status)
            .ToList();
    }

    private List<UTask> GetAllTasks()
    {
        EnsureFileExists();
        var json = File.ReadAllText(FILE_PATH);
        return JsonSerializer.Deserialize<List<UTask>>(json, _jsonOptions) ?? new List<UTask>();
    }

    private void SaveTasks(List<UTask> tasks)
    {
        var json = JsonSerializer.Serialize(tasks, _jsonOptions);
        File.WriteAllText(FILE_PATH, json);
    }

    private bool UpdateTaskProperties(Guid guid, Action<UTask> updateAction)
    {
        try
        {
            var tasks = GetAllTasks();
            var task = tasks.FirstOrDefault(x => x.Id == guid);
            if (task == null) return false;

            updateAction(task);
            SaveTasks(tasks);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private void EnsureFileExists()
    {
        if (!FileSystemValidation.FileExist())
        {
            FileSystemValidation.CreateTaskFile();
        }
    }

    private void PrintTask(UTask task)
    {
        Console.WriteLine(
            $"ID: {task.Id}, " +
            $"Desc: {task.Description}, " +
            $"Status: {task.UTaskStatus.GetDescription()}, " +
            $"Created: {task.CreatedAt:g}\n"
        );
    }
}