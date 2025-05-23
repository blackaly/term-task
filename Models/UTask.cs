using Models.Nums;

namespace Models;

public class UTask
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public UTaskStatus UTaskStatus { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public UTask(Guid id, string Description, UTaskStatus uTaskStatus, DateTime CreatedAt, DateTime UpdatedAt)
    {
        this.Id = id;
        this.Description = Description;
        this.UTaskStatus = uTaskStatus;
        this.CreatedAt = CreatedAt;
        this.UpdatedAt = UpdatedAt;
    }
}