using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoJorgeManzano.Models;

namespace ProyectoJorgeManzano.Controllers
{
    public class EquipoController : Controller
    {
        private Contexto Contexto;
        public EquipoController(Contexto contexto)
        {
            Contexto = contexto;
            Contexto.Database.EnsureCreated();
        }
        // GET: EquipoController
        public ActionResult Index()
        {
            var equipos = Contexto.Equipos.Include(e => e.competicionesEquipos)
                .ThenInclude(ce => ce.competicion).ToList();
            
            foreach (var eq in equipos)
            {
                eq.pais = Contexto.Paises.Where(p => p.id.Trim().Equals(eq.paisId)).Single();
            }
            return View(equipos);
        }

        // GET: EquipoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EquipoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquipoController/Create
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

        // GET: EquipoController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.paisID = new SelectList(Contexto.Paises, "id", "countryName");
            ViewBag.competicionesSeleccionadas = new MultiSelectList(Contexto.Competiciones, "id", "name", Contexto.CompeticionesEquipos.Where(e => e.equipoID == id).Select(e => e.competicionID));
            return View(Contexto.Equipos.Find(id));
        }

        // POST: EquipoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EquipoModelo equipoEditado)
        {
            try
            {
                List<int> extrasIdsYaAnadidos = Contexto.CompeticionesEquipos.Where(e => e.equipoID == id).Select(e => e.competicionID).ToList();
                Contexto.Equipos.Update(equipoEditado);
                Contexto.SaveChanges();
                foreach (var idS in equipoEditado.competicionesSeleccionadas)
                {
                    if (extrasIdsYaAnadidos.Contains(idS)) continue;
                    Contexto.CompeticionesEquipos.Add
                    (
                        new CompeticionEquipoModelo()
                        {
                            competicionID = idS,
                            equipoID = equipoEditado.id
                        }
                    );
                }
                Contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EquipoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EquipoController/Delete/5
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
        public ActionResult EquiposPorPais(string id)
        {            
            ViewBag.pais = Contexto.Paises.Find(id);
            return View(Contexto.Equipos.Where(e => e.paisId.Trim().Equals(id)));
        }
    }
}
