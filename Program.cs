using Microsoft.Data.Sqlite;
using NetworkLogger.Data;
using NetworkLogger.Services;

const string connectionString = "Data Source=network_logs.db";
const int intervalSeconds = 5;

// DB hazır mı kontrol et
DatabaseInitializer.Initialize(connectionString);

Console.WriteLine("Network Logger started...");

while (true)
{
    try
    {
        var timestamp = DateTime.UtcNow;

        var tcpConnections = NetworkCaptureService.GetTcpConnections(timestamp);
        var tcpListeners = NetworkCaptureService.GetTcpListeners(timestamp);
        var udpListeners = NetworkCaptureService.GetUdpListeners(timestamp);

        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        TrafficLogRepository.InsertLogs(connection, tcpConnections);
        TrafficLogRepository.InsertLogs(connection, tcpListeners);
        TrafficLogRepository.InsertLogs(connection, udpListeners);

        Logger.Log(
            $"TCP: {tcpConnections.Count}, TCP Listener: {tcpListeners.Count}, UDP Listener: {udpListeners.Count}"
        );
    }
    catch (Exception ex)
    {
        Logger.LogError(ex);
    }

    Thread.Sleep(TimeSpan.FromSeconds(intervalSeconds));
}