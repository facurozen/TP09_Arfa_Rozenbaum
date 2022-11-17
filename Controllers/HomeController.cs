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

    public IActionResult Index(int IdGenero=0)
    {
        ViewBag.Usuario = BD.ObtenerUsuario();
            ViewBag.ListaGeneros=BD.ObtenerGeneros();
        if(IdGenero==0){
        ViewBag.ListaPeliculas=BD.ObtenerPeliculas();

        }else{
        ViewBag.ListaPeliculas=BD.ObtenerPeliculasPorGenero(IdGenero);

        }
        return View();
    }
    [HttpPost]
    public IActionResult IndexPorGenero(int IdGenero=0)
    {
        ViewBag.Usuario = BD.ObtenerUsuario();
            ViewBag.ListaGeneros=BD.ObtenerGeneros();
        if(IdGenero==0){
        ViewBag.ListaPeliculas=BD.ObtenerPeliculas();

        }else{
        ViewBag.ListaPeliculas=BD.ObtenerPeliculasPorGenero(IdGenero);
        //ViewBag.NombreGenero = BD.ObtenerNombreGenero(IdGenero);
        }
        return View("Index");
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult IniciarSesion(string Nombre, string Email, string Contraseña)
    {
        Usuario u = BD.IniciarSesion(Nombre, Email, Contraseña);
        if (u == null)
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
    public int DarLike(int IdPelicula){
        BD.DarLike(IdPelicula);
        return BD.ObtenerLikes(IdPelicula);
    }

    [HttpPost]
    public bool escribirComentario(Comentario c){
        BD.escribirComentario(c);
        return true;
    }
    [HttpPost]
    public List<Comentario> mostrarComentario(Comentario c, int IdPelicula){
        return  BD.ObtenerComentariosPorPelicula(IdPelicula);
        
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
