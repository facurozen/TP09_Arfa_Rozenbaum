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

    public IActionResult Index(int idGenero)
    {
        ViewBag.Usuario = BD.ObtenerUsuario();
        ViewBag.ListaPeliculas=BD.LevantarPeliculas();
        ViewBag.ListaGeneros = BD.LevantarGeneros();
        ViewBag.ListaPeliculasPorGenero = BD.LevantarPeliculasPorGenero(idGenero);
        ViewBag.NombreGenero = BD.LevantarNombreGenero(idGenero);
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult IniciarSesion(string Nombre, string Email, string Contraseña)
    {
        BD.IniciarSesion(Nombre, Email, Contraseña);
        if (BD.ObtenerUsuario() == null)
        {
            return RedirectToAction("Login");
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    public IActionResult CargarPeliculasPorCategoria(int idCategoria){
        
        return View();
    }


    public IActionResult Reproductor(int IdPelicula){
        ViewBag.Pelicula=BD.LevantarPelicula(IdPelicula);
        ViewBag.Video=BD.ObtenerVideo(IdPelicula);
        return View();
    }

    public IActionResult AdministrarPeliculas(){
        if(BD.ObtenerUsuario()==null){
            return RedirectToAction("Index");
        }else{
            ViewBag.ListaPeliculas=BD.LevantarPeliculas();
            return View();
        }
    }

    public IActionResult EliminarPelicula(int IdPelicula){
        if(BD.ObtenerUsuario()==null){
            return RedirectToAction("Index");
        }else{
            BD.EliminarPelicula(IdPelicula);
            return RedirectToAction("AdministrarPeliculas");
        }
    }

    public IActionResult AgregarPelicula(){
        if(BD.ObtenerUsuario()==null){
            return RedirectToAction("Index");
        }else{
            ViewBag.ListaGeneros = BD.LevantarGeneros();
            return View();
        }
    }

    [HttpPost]
    public IActionResult GuardarPelicula(IFormFile arPortada,Pelicula p){
        if(BD.ObtenerUsuario()==null){
            return RedirectToAction("Index");
        }else{
            
            if(arPortada.Length>0){
                string dirPortadas=this.Environment.ContentRootPath+@"\wwwroot\"+arPortada.FileName;
                using(var stream=System.IO.File.Create(dirPortadas)){
                    arPortada.CopyToAsync(stream);
                }
            }
            p.Portada=arPortada.FileName;
            BD.AgregarPelicula(p);
            //BD.AgregarVideo
            return RedirectToAction("AdministrarPeliculas");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
