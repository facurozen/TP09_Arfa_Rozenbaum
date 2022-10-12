using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP09_Arfa_Rozenbaum.Models;

namespace TP09_Arfa_Rozenbaum.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Usuario = BD.ObtenerUsuario();
        return View();
    }

    public IActionResult Registro()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult IniciarSesion(string Nombre, string Contraseña)
    {
        BD.IniciarSesion(Nombre, Contraseña);
        if (BD.ObtenerUsuario() == null)
        {
            return RedirectToAction("Login");
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Registrar(Usuarios u)
    {
        if (BD.VerificarRegistro(u.Nombre, u.Email))
        {
            BD.AgregarUsuario(u);
            BD.IniciarSesion(u.Nombre, u.Contraseña);
            return RedirectToAction("Index");
        }
        else
        {
            return RedirectToAction("Registro");
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
