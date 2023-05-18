using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class EntrepriseController : Controller
    {
        private readonly IServiceEntreprise entrepriseService;
        public EntrepriseController(IServiceEntreprise se)
        {
            
            entrepriseService = se;
        }
        // GET: EntrepriseController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EntrepriseController/Details/5
        public ActionResult Details(int id)
        {
            return View(entrepriseService.GetById(id));
        }

        // GET: EntrepriseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntrepriseController/Create
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

        // GET: EntrepriseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EntrepriseController/Edit/5
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

        // GET: EntrepriseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EntrepriseController/Delete/5
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
