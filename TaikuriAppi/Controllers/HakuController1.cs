using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaikuriAppi.Controllers
{
    public class HakuController1 : Controller
    {
        // GET: HakuController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: HakuController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HakuController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HakuController1/Create
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

        // GET: HakuController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HakuController1/Edit/5
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

        // GET: HakuController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HakuController1/Delete/5
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
