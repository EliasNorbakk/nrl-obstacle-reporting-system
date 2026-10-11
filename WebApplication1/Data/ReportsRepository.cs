using MySqlConnector;
using Dapper;

namespace WebApplication1.Data
{
    /// <summary>
    /// Repository som håndterer lagring av data i databasen (Reports-tabellen).
    /// </summary>
    public class ReportsRepository
    {
        private readonly MySqlDataSource _datasource;

        /// <summary>
        /// Lager et nytt repository og kobler det til databasekilden.
        /// </summary>
        public ReportsRepository(MySqlDataSource datasource)
        {
            _datasource = datasource;
        }

        /// <summary>
        /// Lagrer et nytt hinder i databasen.
        /// </summary>
        /// <param name="name">Navn på hinderet</param>
        /// <param name="height">Høyde på hinderet</param>
        /// <param name="desc">Beskrivelse</param>
        /// <param name="locJson">Lokasjon som JSON (lat/lng fra kartet)</param>
        /// <returns>Id til raden som ble lagt inn, eller 0 hvis det feilet</returns>
        public async Task<int> CreateAsync(string? name, decimal? height, string? desc, string? locJson)
        {
            // SQL-spørring for å legge til en rad i Reports-tabellen
            const string sql = @"INSERT INTO obstacledb.Reports 
                (ObstacleName, ObstacleHeight, ObstacleDescription, ObstacleLocation)
                VALUES (@ObstacleName, @ObstacleHeight, @ObstacleDescription, @ObstacleLocation);";

            // Åpner en kobling til databasen
            await using var conn = await _datasource.OpenConnectionAsync();

            // Utfører spørringen med verdiene vi sender inn
            int rows = await conn.ExecuteAsync(sql, new
            {
                ObstacleName = name,
                ObstacleHeight = height,
                ObstacleDescription = desc,
                ObstacleLocation = locJson
            });

            // Henter ID til raden vi nettopp la inn
            int id = await conn.ExecuteScalarAsync<int>("SELECT LAST_INSERT_ID();");

            // Hvis vi la inn 1 rad, returner ID, ellers returner 0
            return rows == 1 ? id : 0;
        }
    }
}
