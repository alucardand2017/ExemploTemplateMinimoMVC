using Microsoft.AspNetCore.Mvc;

namespace AULA08MVCTEMPLATEMINIMO.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

        public IActionResult Cadastrar()
    {
        return View("FormUsuario");
    }
}