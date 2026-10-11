using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controller som håndterer skjema for å registrere hinder.
    /// </summary>
    public class ObstacleController : Controller
    {
        // Repository brukes til å lagre data i databasen
        private readonly ReportsRepository _repo;

        public ObstacleController(ReportsRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Viser skjemaet for å registrere et nytt hinder (GET).
        /// </summary>
        [HttpGet]
        public ActionResult DataForm()
        {
            return View();
        }

        /// <summary>
        /// Tar imot skjema-data (POST).
        /// Hvis data er gyldige lagres de i databasen og vi viser en oversiktsside.
        /// Hvis noe er feil, vises skjemaet på nytt med feilmeldinger.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> DataForm(ObstacleData obstacleData)
        {
            // Sjekker at modellen er gyldig (validering fra ObstacleData)
            if (!ModelState.IsValid)
            {
                return View(obstacleData);
            }

            try
            {
                // Lagrer data i databasen via repository
                int newId = await _repo.CreateAsync(
                    obstacleData.ObstacleName,
                    obstacleData.ObstacleHeight,
                    obstacleData.ObstacleDescription,
                    obstacleData.ObstacleLocation
                );

                // Gir beskjed om at lagring var vellykket
                ViewBag.SavedReportId = newId;
                TempData["Success"] = "Report saved with ID " + newId;
            }
            catch (System.Exception ex)
            {
                // Viser en feilmelding hvis databasen ikke svarer
                ModelState.AddModelError(string.Empty, "Database error: " + ex.Message);
                return View(obstacleData);
            }

            // Viser oversiktssiden med dataene etter at de er lagret
            return View("Overview", obstacleData);
        }
    }
}
