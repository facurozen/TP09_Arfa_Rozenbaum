using System;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Http;

namespace TP09_Arfa_Rozenbaum.Models;

public class BD
{
    private static Usuarios u = new Usuarios();
    private static string _connectionString = @"Server=DESKTOP-5JS9G07\SQLEXPRESS;DataBase=Mr.Peliculas;Trusted_Connection=True;";

    public static List<Peliculas> LevantarPeliculas()
    {
        string sql = "SELECT * FROM Peliculas";
        List<Peliculas> l = new List<Peliculas>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            l = db.Query<Peliculas>(sql).ToList();
        }
        return l;
    }

    public static List<Peliculas> LevantarPeliculasPorGenero(int IdGenero)
    {
        string sql = "SELECT p.* FROM Peliculas AS p INNER JOIN GeneroPorPelicula AS gp ON p.IdPelicula=gp.IdPelicula WHERE gp.IdGenero=@pIdGenero";
        List<Peliculas> l = new List<Peliculas>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            l = db.Query<Peliculas>(sql, new { pIdGenero = IdGenero }).ToList();
        }
        return l;
    }

    public static Peliculas LevantarPelicula(int IdPelicula)
    {
        string sql = "SELECT * FROM Peliculas WHERE IdPelicula=@pIdPelicula";
        Peliculas p = new Peliculas();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            p = db.QueryFirstOrDefault<Peliculas>(sql, new { pIdPelicula = IdPelicula });
        }
        return p;
    }

    public static List<Comentarios> LevantarComentariosPorPelicula(int IdPelicula)
    {
        string sql = "SELECT * FROM Comentarios WHERE IdPelicula=@pIdPelicula";
        List<Comentarios> l = new List<Comentarios>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            l = db.Query<Comentarios>(sql, new { pIdPelicula = IdPelicula }).ToList();
        }
        return l;
    }

    public static void AgregarComentario(Comentarios c)
    {
        string sql = "INSERT INTO Comentarios VALUES (@pIdUsuario,@pIdPelicula,@pTexto)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pIdUsuario = c.IdUsuario, pIdPelicula = c.IdPelicula, pTexto = c.Texto });
        }
    }

    public static void AgregarUsuario(Usuarios u)
    {
        string sql = "INSERT INTO Usuarios VALUES (@pNombre, @pEmail, @pContraseña)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pNombre = u.Nombre, pEmail = u.Email, pContraseña = u.Contraseña });
        }
    }

    public static void IniciarSesion(string Nombre, string Contraseña)
    {
        string sql = "SELECT * FROM Usuarios WHERE Nombre=@pNombre AND Contraseña=@pContraseña";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            u = db.QueryFirstOrDefault<Usuario>(sql, new { pNombre = Nombre, pContraseña = Contraseña });
        }
    }

    public static bool VerificarRegistro(string Nombre, string Email)
    {
        string sql = "SELECT * FROM Usuarios WHERE Nombre=@pNombre OR Email=@pEmail";
        Usuarios us = new Usuarios();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            us = db.QueryFirstOrDefault<Usuario>(sql, new { pNombre = Nombre, pEmail = Email });
        }
        return us == null;
    }
    public static Usuarios ObtenerUsuario()
    {
        return u;
    }

    public static void AgregarPelicula(Peliculas p)
    {
        string sql = "INSERT INTO Peliculas VALUES (@pNombre,@pPortada,@pSinopsis,@pDuracion,@pAño)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pNombre = p.Nombre, pPortada = p.Portada, pSinopsis = p.Sinopsis, pAño = p.Año });
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
}
