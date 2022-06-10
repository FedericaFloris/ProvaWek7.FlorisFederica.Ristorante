using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProvaWek7.FlorisFederica.Ristorante.Core.BusinessLayer;
using ProvaWek7.FlorisFederica.Ristorante.MVC.Models;
using ProvaWek7.FlorisFederica.Ristorante.MVC.NewFolder;

namespace ProvaWek7.FlorisFederica.Ristorante.MVC.Controllers
{
    public class PiattiController : Controller
    {
        private readonly IBusinessLayer BL; //per collegarsi alle logiche di business

        public PiattiController(IBusinessLayer bl)
        {
            BL = bl;
        }
        public IActionResult Index()
        {
            var piatti = BL.GetAllPiatto();
            List<PiattoViewModel> piattiViewModel = new List<PiattoViewModel>();
            foreach (var item in piatti)
            {
                piattiViewModel.Add(item.ToPiattoViewModel());
            }
            return View(piattiViewModel);
        }
        [Authorize(Policy = "Ristoratore")]
        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [Authorize(Policy = "Ristoratore")]
        [HttpPost]
        public IActionResult Create(PiattoViewModel piattoViewModel)
        {
            if (ModelState.IsValid)
            {
                var piatto = piattoViewModel.ToPiatto();
                var esito = BL.AggiungiPiatto(piatto);
                if (esito == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.MessaggioErrore = "Il piatto non è stato aggiunto";
                    return View("ErroriDiBusiness");
                }
            }
            else
            {
                
                return View(piattoViewModel);
            }
        }

        [Authorize(Policy = "Ristoratore")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var piatti = BL.GetAllPiatto().FirstOrDefault(s => s.Id == id);
            var piattiViewModel = piatti.ToPiattoViewModel();
            
            return View(piattiViewModel);
        }
        [Authorize(Policy = "Ristoratore")]
        [HttpPost]
        public IActionResult Edit(PiattoViewModel piattoViewModel)
        {
            if (ModelState.IsValid)
            {
                var piatto = piattoViewModel.ToPiatto();
                var esito = BL.ModificaPiatto(piatto.Id,piatto.Prezzo);
                if (esito == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.MessaggioErrore = "Piatto non modificato";
                    return View("ErroriDiBusiness");
                }
            }
            
            return View(piattoViewModel);
        }
        [Authorize(Policy = "Ristoratore")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var piatto = BL.GetAllPiatto().FirstOrDefault(s => s.Id == id);
            var piattoViewModel = piatto.ToPiattoViewModel();
            return View(piattoViewModel);
        }
        [Authorize(Policy = "Ristoratore")]
        [HttpPost]
        public IActionResult Delete(PiattoViewModel piattoViewModel)
        {
            var piatto = piattoViewModel.ToPiatto();
            var esito = BL.EliminaPiatto(piatto.Id);
            if (esito == true)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.MessaggioErrore = "Impossibile eliminare il piatto";
                return View("ErroriDiBusiness");
            }
        }

    }
}
