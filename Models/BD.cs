using System;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Http;

namespace TP09_Arfa_Rozenbaum.Models;

public class BD
{
    private static Usuario u = null;
    private static string _connectionString = @"Server=A-PHZ2-CIDI-045;DataBase=Mr.Peliculas;Trusted_Connection=True;";

    public static List<Pelicula> ObtenerPeliculas()
    {
        string sql = "SELECT * FROM Peliculas";
        List<Pelicula> l = new List<Pelicula>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            l = db.Query<Pelicula>(sql).ToList();
        }
        return l;
    }

    public static List<Pelicula> ObtenerPeliculasPorGenero(int IdGenero)
    {
        string sql = "SELECT p.* FROM Peliculas AS p INNER JOIN GeneroPorPelicula AS gp ON p.IdPelicula=gp.IdPelicula WHERE gp.IdGenero=@pIdGenero";
        List<Pelicula> l = new List<Pelicula>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            l = db.Query<Pelicula>(sql, new { pIdGenero = IdGenero }).ToList();
        }
        return l;
    }

    public static Pelicula ObtenerPelicula(int IdPelicula)
    {
        string sql = "SELECT * FROM Peliculas WHERE IdPelicula=@pIdPelicula";
        Pelicula p = new Pelicula();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            p = db.QueryFirstOrDefault<Pelicula>(sql, new { pIdPelicula = IdPelicula });
        }
        return p;
    }

    public static List<Comentario> ObtenerComentariosPorPelicula(int IdPelicula)
    {
        string sql = "SELECT * FROM Comentarios WHERE IdPelicula=@pIdPelicula";
        List<Comentario> l = new List<Comentario>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            l = db.Query<Comentario>(sql, new { pIdPelicula = IdPelicula }).ToList();
        }
        return l;
    }

    public static void AgregarComentario(Comentario c)
    {
        string sql = "INSERT INTO Comentarios VALUES (@pIdUsuario,@pIdPelicula,@pTexto)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new {pIdPelicula = c.IdPelicula, pTexto = c.Texto });
        }
    }

    public static void AgregarUsuario(Usuario u)
    {
        string sql = "INSERT INTO Usuarios VALUES (@pNombre, @pEmail, @pContraseña)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pNombre = u.Nombre, pEmail = u.Email, pContraseña = u.Contraseña });
        }
    }

    public static void IniciarSesion(string Nombre, string Email, string Contraseña)
    {
        string sql = "SELECT * FROM Usuarios WHERE Nombre=@pNombre AND Email = @pEmail AND Contraseña=@pContraseña";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            u = db.QueryFirstOrDefault<Usuario>(sql, new { pNombre = Nombre, pEmail = Email, pContraseña = Contraseña });
        }
    }
    public static Usuario ObtenerUsuario()
    {
        return u;
    }

    public static void AgregarPelicula(Pelicula p)
    {
        string sql = "INSERT INTO Peliculas VALUES (@pNombre,@pPortada,@pSinopsis,@pDuracion,@pAño)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pNombre = p.Nombre, pPortada = p.Portada, pSinopsis = p.Sinopsis, pDuracion=p.Duracion, pAño = p.Año });
        }
    }

    public static void AgregarVideo(IFormFile v, int IdPelicula)
    {
        string sql = "INSERT INTO Videos VALUES (@pNombre,@pIdPelicula)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pNombre = v.FileName, pIdPelicula = IdPelicula });
        }
    }

    public static Video ObtenerVideo(int IdPelicula)
    {
        string sql = "SELECT * FROM Videos WHERE IdPelicula=@pIdPelicula";
        Video v = new Video();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            v = db.QueryFirstOrDefault<Video>(sql, new { pIdPelicula = IdPelicula });
        }
        return v;
    }
    public static void EliminarPelicula(int IdPelicula){
        string sql1 = "DELETE FROM Videos WHERE IdPelicula=@pIdPelicula";
        string sql2 = "DELETE FROM Peliculas WHERE IdPelicula=@pIdPelicula";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql1, new {pIdPelicula = IdPelicula });
            db.Execute(sql2, new {pIdPelicula = IdPelicula });
        }
    }
}
