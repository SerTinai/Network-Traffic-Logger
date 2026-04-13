# Network Traffic Logger

A lightweight network monitoring tool built with C#, SQLite, and Dapper.  
This project captures active TCP connections and TCP/UDP listeners, then stores structured metadata in SQLite for analysis.

## Features
- Captures active TCP connections
- Captures TCP listeners
- Captures UDP listeners
- Stores traffic metadata in SQLite
- Uses Dapper for lightweight data access
- Supports IPv4 and IPv6 environments
- Writes runtime logs to a local log file

## Technologies
- C#
- .NET
- SQLite
- Dapper

## Project Structure
- `Models/` → data models
- `Data/` → database initialization and repository layer
- `Services/` → logging and network capture services
- `Program.cs` → application entry point

## Usage
```bash
dotnet run
