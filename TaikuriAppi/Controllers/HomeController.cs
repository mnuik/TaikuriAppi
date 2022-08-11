using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaikuriAppi.Models;

namespace TaikuriApp.Controllers
{
    public class HomeController : Controller
    {
        VarausDBContext db = new VarausDBContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string? lokaatio, string? toimialat, string? haku)
        {
            var TaikuriList = db.Taikuris.AsQueryable();

            if (!string.IsNullOrWhiteSpace(lokaatio))
            {
                TaikuriList = TaikuriList.Where(x => x.Lokaatio.Contains(lokaatio));
            }


            if (!string.IsNullOrWhiteSpace(toimialat))
            {
                TaikuriList = TaikuriList.Where(x => x.Toimialat.Contains(toimialat));
            }


            if (!string.IsNullOrWhiteSpace(haku))
            {
                TaikuriList = TaikuriList.Where(x => x.Taiteilijanimi.Contains(haku));
            }


            //// haetaan lokaatiot tietokannasta
            //// splitataan pilkusta
            //// siirretään lokaatiot listaan
            //List<string> lokaatiot = new List<string>();
            //lokaatiot.Add("eka");
            //lokaatiot.Add("toka");
            //ViewData["lokaatiot"] = lokaatiot;

            return View(TaikuriList.ToList());

        }
        [HttpGet]
        public IActionResult Create()
        {

            Taikuri uusi = new Taikuri();
            uusi.Taiteilijanimi = "";
            return View(uusi);

        }
        [HttpPost]
        public IActionResult Create(Taikuri newTaikuri)
        {

            db.Taikuris.Add(newTaikuri);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {

            Taikuri taikuri = db.Taikuris.Find(id);
            return View(taikuri);

        }
        [HttpPost]
        public IActionResult Edit(Taikuri Taikuri)
        {

            db.Taikuris.Update(Taikuri);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Taikuri taikuri = db.Taikuris.Find(id);
            if (taikuri != null)
            {
                db.Taikuris.Remove(taikuri);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}