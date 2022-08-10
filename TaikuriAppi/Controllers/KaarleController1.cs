using Microsoft.AspNetCore.Mvc;

namespace TaikuriAppi.Controllers
{
    public class KaarleController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TaikurinLisäys()
        {
            int taikuriid = input(taikuriid);               // nämä eivät vielä saa arvoja mistään !! 
            string taiteilijanimi = input(taiteilijanimi);
            string toimialat = input(toimialat);
            string taidot = input(taidot);
            string lokaatio = input(lokaatio);

            Taikuri uusiTaikuri = new Taikuri()
            {
                TaikuriId = taikuriid,
                Taiteilijanimi = taiteilijanimi,
                Toimialat = toimialat,
                Taidot = taidot,
                Lokaatio = sijainti
            };

        }

    }
}
