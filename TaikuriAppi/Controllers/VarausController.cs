using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaikuriAppi.Models;
////////////////////////////////////////////////////////////////TÄMÄ EI ENÄÄ OLE KÄYTÖSSÄ
namespace TaikuriAppi.Controllers
{
    public class VarausController : Controller
    {
        // VarausDBContext db = new VarausDBContext();
        private readonly IConfiguration _configuration;
        private readonly ILogger<VarausDBContext> _logger;

        public VarausController(IConfiguration configuration, ILogger<VarausDBContext> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }



        // GET: KantaController1
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Haloo()
        {
            var optionsBuilder = new DbContextOptionsBuilder<VarausDBContext>();

           optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:VarausDB"]);

            var db = new VarausDBContext(optionsBuilder.Options);

            var varaukset = db.Varauksets.ToList();

            return View(varaukset);

           
        }

        // GET: KantaController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KantaController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KantaController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KantaController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KantaController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KantaController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KantaController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
