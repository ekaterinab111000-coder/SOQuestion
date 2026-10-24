using Microsoft.AspNetCore.Mvc;
using SOQuestion.Models;
using System.Diagnostics;

namespace SOQuestion.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new LoginViewModel(Request);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            else
            {
                MultiLanguageViewModel.TranslateModelState(ModelState, model.LanguageId);
            }
            return View(model);
        }
        public IActionResult Success()
        {
            return View(); 
        }
    }
}
