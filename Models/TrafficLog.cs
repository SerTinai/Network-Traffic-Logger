namespace NetworkLogger.Models;

public sealed class TrafficLog
{
    public int Id { get; set; }
    public DateTime TimestampUtc { get; set; }
    public string EntryType { get; set; } = string.Empty;
    public string Protocol { get; set; } = string.Empty;
    public string? LocalAddress { get; set; }
    public int? LocalPort { get; set; }
    public string? RemoteAddress { get; set; }
    public int? RemotePort { get; set; }
    public string? State { get; set; }
    public string? Note { get; set; }
}