using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProvaWek7.FlorisFederica.Ristorante.Core.BusinessLayer;
using ProvaWek7.FlorisFederica.Ristorante.Core.Entities;
using ProvaWek7.FlorisFederica.Ristorante.MVC.Models;
using ProvaWek7.FlorisFederica.Ristorante.MVC.NewFolder;

namespace ProvaWek7.FlorisFederica.Ristorante.MVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly IBusinessLayer BL;
        public MenuController(IBusinessLayer bl)
        {
            BL = bl;
        }
        public IActionResult Index()
        {
            
            List<Menu> menu = BL.GetAllMenu();
            
            List<MenuViewModel> menuViewModels = new List<MenuViewModel>();
            foreach (var item in menu)
            {
                menuViewModels.Add(item.ToMenuViewModel()); 
            }
            return View(menuViewModels);
        }

        public IActionResult Details(int id)
        {
            var menu = BL.GetAllMenu().FirstOrDefault(m => m.Id == id);
            var menuViewModel = menu.ToMenuViewModel();
            return View(menuViewModel);
        }

        [Authorize(Policy = "Ristoratore")]
        [HttpPost]
        public IActionResult Create(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                //dobbiamo aggiungere il corsoViewModel al repository
                Menu menu = menuViewModel.ToMenu();
                bool esito= BL.AggiungiMenu(menu);
                if (esito == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //visualizzo il messaggio d'errore in una pagina
                    ViewBag.MessaggioErrore = "Menu non aggiornato, c'è stato qualche problema";
                    return View("ErroriDiBusiness");
                }
            }
            return View(menuViewModel);
        }

        [Authorize(Policy = "Ristoratore")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var menu = BL.GetAllMenu().FirstOrDefault(m => m.Id == id);
            var menuVM = menu.ToMenuViewModel();
            return View(menuVM);
        }
        [Authorize(Policy = "Ristoratore")]
        [HttpPost]
        public IActionResult Edit(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                var menu = menuViewModel.ToMenu();
                bool esito = BL.ModificaMenu(menu);
                if (esito==true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.MessaggioErrore = "Impossibile aggiornare il menu";
                    return View("ErroriDiBusiness");
                }
            }
            return View(menuViewModel);
        }
    }
}
