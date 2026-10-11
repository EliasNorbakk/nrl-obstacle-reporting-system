using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using MySqlConnector;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controller for hjemmesiden. 
    /// Viser startside, personvernside og feilside.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string connectionString;

        /// <summary>
        /// Henter connection string fra konfigurasjonen (appsettings.json).
        /// </summary>
        public HomeController(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Tester om vi klarer å koble til databasen. 
        /// Viser en melding på forsiden om det gikk bra eller ikke.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            string successMessage = "Connected to MariaDB successfully!";
            string errorMessage = "Failed to connect to MariaDB.";

            try
            {
                // Prøver å åpne en kobling til databasen
                await using var conn = new MySqlConnection(connectionString);
                await conn.OpenAsync();

                // Hvis det går bra vises en suksessmelding
                return View("Index", successMessage);
            }
            catch (Exception ex)
            {
                // Hvis noe går galt, vis en feilmelding
                return View("Index", errorMessage + " " + ex.Message);
            }
        }

        /// <summary>
        /// Viser personvernsiden.
        /// </summary>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Viser feilsiden med informasjon om RequestId (nyttig for feilsøking).
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
