using Dapper;
using Microsoft.Data.Sqlite;

namespace NetworkLogger.Data;

public static class DatabaseInitializer
{
    public static void Initialize(string connectionString)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        const string createTableSql = """
            CREATE TABLE IF NOT EXISTS TrafficLogs
            (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                TimestampUtc TEXT NOT NULL,
                EntryType TEXT NOT NULL,
                Protocol TEXT NOT NULL,
                LocalAddress TEXT,
                LocalPort INTEGER,
                RemoteAddress TEXT,
                RemotePort INTEGER,
                State TEXT,
                Note TEXT
            );
            """;

        const string createTimestampIndexSql = """
            CREATE INDEX IF NOT EXISTS IX_TrafficLogs_TimestampUtc
            ON TrafficLogs(TimestampUtc);
            """;

        const string createProtocolIndexSql = """
            CREATE INDEX IF NOT EXISTS IX_TrafficLogs_Protocol
            ON TrafficLogs(Protocol);
            """;

        const string createEntryTypeIndexSql = """
            CREATE INDEX IF NOT EXISTS IX_TrafficLogs_EntryType
            ON TrafficLogs(EntryType);
            """;

        connection.Execute(createTableSql);
        connection.Execute(createTimestampIndexSql);
        connection.Execute(createProtocolIndexSql);
        connection.Execute(createEntryTypeIndexSql);
    }
}