using Dapper;
using Microsoft.Data.Sqlite;
using NetworkLogger.Models;

namespace NetworkLogger.Data;

public static class TrafficLogRepository
{
    public static void InsertLogs(SqliteConnection connection, List<TrafficLog> logs)
    {
        if (logs.Count == 0)
            return;

        const string sql = """
            INSERT INTO TrafficLogs
            (
                TimestampUtc,
                EntryType,
                Protocol,
                LocalAddress,
                LocalPort,
                RemoteAddress,
                RemotePort,
                State,
                Note
            )
            VALUES
            (
                $TimestampUtc,
                $EntryType,
                $Protocol,
                $LocalAddress,
                $LocalPort,
                $RemoteAddress,
                $RemotePort,
                $State,
                $Note
            );
            """;

        foreach (var log in logs)
        {
            var parameters = new DynamicParameters();
            parameters.Add("$TimestampUtc", log.TimestampUtc.ToString("o"));
            parameters.Add("$EntryType", log.EntryType);
            parameters.Add("$Protocol", log.Protocol);
            parameters.Add("$LocalAddress", log.LocalAddress);
            parameters.Add("$LocalPort", log.LocalPort);
            parameters.Add("$RemoteAddress", log.RemoteAddress);
            parameters.Add("$RemotePort", log.RemotePort);
            parameters.Add("$State", log.State);
            parameters.Add("$Note", log.Note);

            connection.Execute(sql, parameters);
        }
    }
}