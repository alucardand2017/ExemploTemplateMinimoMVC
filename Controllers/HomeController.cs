using AULA08MVCTEMPLATEMINIMO.Models;
using Microsoft.AspNetCore.Mvc;

namespace AULA08MVCTEMPLATEMINIMO.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Cadastrar(int? id)
    {
        try
        {
            if(id.HasValue && Usuario.Listagem.Any(u=>u.Id == id))
            {
                var usuario = Usuario.Listagem.Single(p=> p.Id == id);
            return View(usuario);
            }
            return View();
        }
        catch( Exception e)
        {
            throw new ArgumentException("Erro na tentativa de enviar para a View. Erro: " + e.Message);
        }
    }

    [HttpPost]
    public IActionResult Cadastrar(Usuario usuario){
        Usuario.Salvar(usuario);
        return RedirectToAction("Usuarios");
    }

    [HttpGet]
    public IActionResult Usuarios()
    {
        ViewBag.QntUsuarios = Usuario.Listagem.Count();
        return View(Usuario.Listagem);
    }
    
    [HttpGet]
    public IActionResult Excluir(int? id)
    {
        var usuario = Usuario.Listagem.First(a=>a.Id == id);
        if(usuario == null)
            return RedirectToAction("Usuarios");
        else{
            return View(usuario);
        }
    }

    [HttpPost]
     public IActionResult Excluir(Usuario usuario)
    {

        Usuario.Excluir(usuario.Id);
        
        return View("Usuarios", Usuario.Listagem);

    }

}