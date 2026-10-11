using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controller som viser skjema-siden.
    /// </summary>
    public class FormController : Controller
    {
        /// <summary>
        /// Viser standardsiden for skjemaet (Index).
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }
    }
}
