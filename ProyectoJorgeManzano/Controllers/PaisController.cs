using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoJorgeManzano.Models;

namespace ProyectoJorgeManzano.Controllers
{
    public class PaisController : Controller
    {
        private Contexto Contexto;
        public PaisController(Contexto contexto)
        {
            Contexto = contexto;
            Contexto.Database.EnsureCreated();
        }
        // GET: PaisController
        public ActionResult Index()
        {
            return View(Contexto.Paises);
        }

        // GET: PaisController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PaisController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaisController/Create
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

        // GET: PaisController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaisController/Edit/5
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

        // GET: PaisController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaisController/Delete/5
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
