using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP09_Arfa_Rozenbaum.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace TP09_Arfa_Rozenbaum.Controllers;

public class AdministradorController : Controller
{
    private readonly ILogger<AdministradorController> _logger;

    private IWebHostEnvironment Environment;

    public AdministradorController(IWebHostEnvironment environment)
    {
        Environment=environment;
    }

    public IActionResult AdministrarPeliculas(){
        if(BD.ObtenerUsuario()==null){
            return RedirectToAction("Index","Home");
        }else{
            ViewBag.ListaPeliculas=BD.ObtenerPeliculas();
            return View();
        }
    }

    public IActionResult EliminarPelicula(int IdPelicula){
        if(BD.ObtenerUsuario()==null){
            return RedirectToAction("Index","Home");
        }else{
            Pelicula p=BD.ObtenerPelicula(IdPelicula);
            Video v=BD.ObtenerVideo(IdPelicula);
            BD.EliminarPelicula(IdPelicula);
            System.IO.File.Delete(this.Environment.ContentRootPath+@"\wwwroot\"+p.Portada);
            System.IO.File.Delete(this.Environment.ContentRootPath+@"\wwwroot\"+v.ArchivoVideo);
            return RedirectToAction("AdministrarPeliculas");
        }
    }

    public IActionResult AgregarPelicula(){
        if(BD.ObtenerUsuario()==null){
            return RedirectToAction("Index","Home");
        }else{
            return View();
        }
    }

    [HttpPost]
    public IActionResult GuardarPelicula(IFormFile arPortada,Pelicula p,IFormFile arVideo){
        if(BD.ObtenerUsuario()==null){
            return RedirectToAction("Index","Home");
        }else{          
            if(arPortada.Length>0){
                string dirPortadas=this.Environment.ContentRootPath+@"\wwwroot\"+arPortada.FileName;
                using(var stream=System.IO.File.Create(dirPortadas)){
                    arPortada.CopyTo(stream);
                }
            }
            if(arVideo.Length>0){
                string dirVideos=this.Environment.ContentRootPath+@"\wwwroot\"+arVideo.FileName;
                using(var stream=System.IO.File.Create(dirVideos)){
                    arVideo.CopyTo(stream);
                }
            }
            p.Portada=arPortada.FileName;
            p=BD.AgregarPelicula(p);
            Video v=new Video(0,arVideo.FileName,p.Duracion,p.IdPelicula);
            BD.AgregarVideo(v);
            return RedirectToAction("AdministrarPeliculas");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
