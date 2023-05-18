using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class CagnotteController : Controller
    {
        private readonly IServiceCagnotte cagnotteService;
        private readonly IServiceEntreprise entrepriseService;
        public CagnotteController(IServiceCagnotte sc, IServiceEntreprise se)
        {
            cagnotteService = sc;
            entrepriseService = se;
        }
        // GET: CagnotteController
        public ActionResult Index()
        {
            return View(cagnotteService.GetMany());
        }
        // Post: CagnotteController/Index
        [HttpPost]
        public ActionResult Index(string filter)
        {
            var list = cagnotteService.GetMany();
            if (!String.IsNullOrEmpty(filter))
            {
                list = list.Where(p => p.Titre.ToString().Equals(filter)).ToList();
            }
            return View(list);
        }

        // GET: CagnotteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult EnCours()
        {
            return View(cagnotteService.Encours());
        }

        // GET: CagnotteController/Create
        public ActionResult Create()
        {
            var entreprises = entrepriseService.GetMany();
            ViewBag.EntrepriseId = new SelectList(entreprises, "EntrepriseId", "NomEntreprise");


            return View();
        }

        // POST: CagnotteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cagnotte c, IFormFile file)
        {
            c.Photo = file.FileName;
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",
               file.FileName);
                using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            try
            {
                cagnotteService.Add(c);
                cagnotteService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CagnotteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CagnotteController/Edit/5
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

        // GET: CagnotteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CagnotteController/Delete/5
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
