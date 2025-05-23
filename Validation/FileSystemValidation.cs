namespace Validation;

public static class FileSystemValidation
{
    private static string FolderName = "TasklistApp";
    private static string FileName = "tasks";
    private static string PATH = $"C:\\Users\\{Environment.UserName}\\Documents\\";
    public static string FullPATH = $"{PATH}{FolderName}\\{FileName}.json";
    public static bool FileExist() => File.Exists(FullPATH);
    public static bool CreateTaskFile()
    {
        string directoryPath = Path.Combine(PATH, FileSystemValidation.FolderName);
        string filePath = Path.Combine(directoryPath, FileSystemValidation.FileName);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            File.WriteAllText($"{filePath}.json", "[]");
            return true;
        }


        if (!File.Exists(filePath))
        {
            File.WriteAllText($"{filePath}.json", @"
            [
            
            ]");
            return true;
        }


        return false;
        
    }
}