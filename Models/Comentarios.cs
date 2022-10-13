using System;

namespace TP09_Arfa_Rozenbaum.Models
{ 
    public class Comentario
    {
        private int _IdComentario;
        private int _IdPelicula;
        private string _Texto;
        public Comentario(int IdComentario, int IdPelicula, string Texto)
        {
            _IdComentario = IdComentario;
            _IdPelicula = IdPelicula;
            _Texto = Texto;
        }
        public Comentario(){}

        public int IdComentario
        {
            get {return _IdComentario;}
            set{_IdComentario = value;}
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