using System;
namespace NetworkLogger.Services;

    public static class Logger
{
    private const string LogFilePath = "app.log";
    public static void Log (string message)
    {
        string line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message} ";
        Console.WriteLine(line);
        File.AppendAllText(LogFilePath,line + Environment.NewLine);
    }
    public static void LogError(Exception ex)
    {
        string line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Error: {ex.Message}";
        Console.WriteLine(line);
        File.AppendAllText(LogFilePath,line + Environment.NewLine);
    }
}

