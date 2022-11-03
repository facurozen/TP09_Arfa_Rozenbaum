using System;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Http;

namespace TP09_Arfa_Rozenbaum.Models;

public class BD
{
    private static Usuario u = new Usuario(1,"Administrador","admin@gmail.com","administrador");
    // private static Usuario u =null;
    private static string _connectionString = @"Server=A-PHZ2-CIDI-041;DataBase=Mr.Peliculas;Trusted_Connection=True;";

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

    public static List<Genero> ObtenerGeneros()
    {
        string sql = "SELECT * FROM Generos";
        List<Genero> g = new List<Genero>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            g = db.Query<Genero>(sql).ToList();
        }
        return g;
    }

    public static List<Pelicula> ObtenerPeliculasPorGenero(int IdGenero)
    {
        string sql = "SELECT * FROM Peliculas WHERE IdGenero=@pIdGenero";
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

    public static void escribirComentario(Comentario c)
    {
        string sql = "INSERT INTO Comentarios VALUES (@pIdPelicula,@pTexto)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new {pIdPelicula = c.IdPelicula, pTexto = c.Texto });
        }
    }

    public static Usuario IniciarSesion(string Nombre, string Email, string Contraseña)
    {
        string sql = "SELECT * FROM Usuarios WHERE Nombre=@pNombre AND Email = @pEmail AND Contraseña=@pContraseña";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            u = db.QueryFirstOrDefault<Usuario>(sql, new { pNombre = Nombre, pEmail = Email, pContraseña = Contraseña });
        }
        return u;
    }
    public static Usuario ObtenerUsuario()
    {
        return u;
    }

    public static Pelicula AgregarPelicula(Pelicula p)
    {
        string sql1= "INSERT INTO Peliculas VALUES (@pNombre,@pPortada,@pSinopsis,@pDuracion,@pAño,@pIdGenero,0)";
        string sql2="SELECT TOP 1 * FROM Peliculas ORDER BY IdPelicula DESC";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql1, new { pNombre = p.Nombre, pPortada = p.Portada, pSinopsis = p.Sinopsis, pDuracion=p.Duracion, pAño = p.Año,pIdGenero=p.IdGenero });
            p = db.QueryFirstOrDefault<Pelicula>(sql2);
        }
        return p;
    }

    public static void AgregarVideo(Video v)
    {
        string sql = "INSERT INTO Videos VALUES (@pNombre,@pDuracion,@pIdPelicula)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pNombre=v.ArchivoVideo,pDuracion=v.Duracion,pIdPelicula=v.IdPelicula });
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
        string sql2="DELETE FROM Comentarios WHERE IdPelicula=@pIdPelicula";
        string sql3 = "DELETE FROM Peliculas WHERE IdPelicula=@pIdPelicula";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql1, new {pIdPelicula = IdPelicula });
            db.Execute(sql2, new {pIdPelicula = IdPelicula });
            db.Execute(sql3, new {pIdPelicula = IdPelicula });
        }
    }
    public static void DarLike(int IdPelicula)
    {
        string sql = "UPDATE Peliculas SET CantLikes = CantLikes + 1 WHERE IdPelicula=@pIdPelicula";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pIdPelicula = IdPelicula });
        }
    }
    public static int ObtenerLikes(int IdPelicula)
    {
        string sql = "SELECT CantLikes FROM Peliculas WHERE IdPelicula=@pIdPelicula";
        Pelicula p = new Pelicula();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            p = db.QueryFirstOrDefault<Pelicula>(sql, new { pIdPelicula = IdPelicula });
        }
        return p.CantLikes;
    }
}
