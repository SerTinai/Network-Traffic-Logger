using System.Diagnostics.SymbolStore;
using System.Net.NetworkInformation;
using Microsoft.VisualBasic;
using NetworkLogger.Models;

namespace NetworkLogger.Services;

public static class NetworkCaptureService
{
    public static List<TrafficLog> GetTcpConnections(DateTime timestampUtc)
    {
        var logs = new List<TrafficLog>();
        IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
        TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();

        foreach(var item in connections)
        {
            logs.Add (new TrafficLog
        {
            TimestampUtc = timestampUtc,
            EntryType= "Connection",
            Protocol= "TCP",
            LocalAddress= item.LocalEndPoint.Address.ToString(),
            LocalPort= item.LocalEndPoint.Port,
            RemoteAddress= item.RemoteEndPoint.Address.ToString(),
            RemotePort= item.RemoteEndPoint.Port,
            State = item.State.ToString(),
            Note = "Active TCP connection"
        });
        }
        return logs;
    }
    public static List<TrafficLog> GetTcpListeners(DateTime timetampUtc)
    {
     var logs = new List<TrafficLog>();
     
     IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
     var listeners = properties.GetActiveTcpListeners();

     foreach (var endpoint in listeners)
     {
        logs.Add(new TrafficLog
        {
            TimestampUtc = timetampUtc,
            EntryType= "Connection",
            Protocol= "TCP",
            LocalAddress= endpoint.Address.ToString(),
            LocalPort= endpoint.Port,
            RemoteAddress= null,
            RemotePort= null,
            State = "Listening",
            Note = "Active TCP listener"

        });
     }
     return logs;
    }
    public static List<TrafficLog> GetUdpListeners(DateTime timetampUtc)
    {
        var logs = new List<TrafficLog>();
        IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
        var listeners = properties.GetActiveUdpListeners();

        foreach(var endpoint in listeners)
        {
            logs.Add( new TrafficLog
            {
             TimestampUtc = timetampUtc,
            EntryType= "Listener",
            Protocol= "UDP",
            LocalAddress= endpoint.Address.ToString(),
            LocalPort= endpoint.Port,
            RemoteAddress= null,
            RemotePort= null,
            State = "Listening",
            Note = "Active UDP listener"   
            });
            
        }

        return logs;
    }
    
}