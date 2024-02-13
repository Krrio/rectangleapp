using Microsoft.AspNetCore.Mvc;
using Zadanko.Models;
using Zadanko.Services;

namespace Zadanko.Controllers
{
    public class ProstokatController : Controller
    {
        private readonly ProstokatSerwis _serwis;

        public ProstokatController(ProstokatSerwis serwis)
        {
            _serwis = serwis;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Oblicz(int wysokosc, int szerokosc, JednostkaDlugosci jednostka)
        {
            var prostokat = new Prostokat
            {
                Wysokosc = wysokosc,
                Szerokosc = szerokosc,
                Jednostka = jednostka
            };

            _serwis.DodajProstokat(prostokat);

            return RedirectToAction("Wynik", new { id = prostokat.Id });
        }

        public IActionResult Lista()
        {
            var model = _serwis.PobierzListeProstokatow();
            return View(model);
        }

        public IActionResult Wynik(int id)
        {
            var prostokat = _serwis.PobierzProstokat(id);
            if (prostokat == null)
            {
                return NotFound();
            }

            return View(prostokat);
        }
    }
}
