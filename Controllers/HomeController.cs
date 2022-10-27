using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP09_Arfa_Rozenbaum.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace TP09_Arfa_Rozenbaum.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private IWebHostEnvironment Environment;

    public HomeController(IWebHostEnvironment environment)
    {
        Environment=environment;
    }

    public IActionResult Index()
    {
        ViewBag.Usuario = BD.ObtenerUsuario();
        ViewBag.ListaPeliculas=BD.ObtenerPeliculas();
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult IniciarSesion(string Nombre, string Email, string Contraseña)
    {
        Usuario p = BD.IniciarSesion(Nombre, Email, Contraseña);
        if (p == null)
        {
            return RedirectToAction("Login");
        }
        else
        {
            return RedirectToAction("AdministrarPeliculas","Administrador");
        }
    }

    public IActionResult Reproductor(int IdPelicula){
        ViewBag.Pelicula=BD.ObtenerPelicula(IdPelicula);
        ViewBag.Video=BD.ObtenerVideo(IdPelicula);
        return View();
    }

    [HttpPost]
    public IActionResult AgregarComentario(Comentario c){
        BD.GuardarComentario(c);
        return RedirectToAction("Reproductor",new{IdPelicula=c.IdPelicula});
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
