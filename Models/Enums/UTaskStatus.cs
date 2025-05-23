using System.ComponentModel; 

namespace Models.Nums;

public enum UTaskStatus
{
    [Description("In Complete")]
    InComplete,
    [Description("In Progress")]
    InProgress,
    [Description("Complete")]
    Complete
}