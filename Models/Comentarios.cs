using System;

namespace TP09_Arfa_Rozenbaum.Models
{ 
    public class Comentarios
    {
        private int _IdComentario;
        private int _IdUsuario; 
        private int _IdPelicula;
        private string _Texto;
        public Comentarios(int IdComentario, int IdUsuario, int IdPelicula, string Texto)
        {
            _IdComentario = IdComentario;
            _IdUsuario = IdUsuario;
            _IdPelicula = IdPelicula;
            _Texto = Texto;
        }
        public Comentarios(){}

        public int IdComentario
        {
            get {return _IdComentario;}
            set{_IdComentario = value;}
        }
        public int IdUsuario
        {
            get {return _IdUsuario;}
            set{_IdUsuario = value;}
        }
        public int IdPelicula
        {
            get {return _IdPelicula;}
            set{_IdPelicula = value;}
        }
        public string Texto
        {
            get {return _Texto;}
            set{_Texto = value;}
        }
    }
}