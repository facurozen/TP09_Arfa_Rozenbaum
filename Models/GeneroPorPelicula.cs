using System;

namespace TP09_Arfa_Rozenbaum.Models
{ 
    public class GeneroPorPelicula
    {
        private int _IdGeneroPelicula;
        private int _IdGenero;
        private int _IdPelicula;

        public GeneroPorPelicula(int IdGeneroPelicula, int IdGenero, int IdPelicula)
        { 
            _IdGeneroPelicula = IdGeneroPelicula;
            _IdGenero = IdGenero;
            _IdPelicula = IdPelicula;
        }
        public GeneroPorPelicula(){}

        public int IdGeneroPelicula
        {
            get {return _IdGeneroPelicula;}
            set{_IdGeneroPelicula = value;}
        }
        public int IdGenero
        {
            get {return _IdGenero;}
            set{_IdGenero = value;}
        }
        public string  IdPelicula
        {
            get {return _IdPelicula;}
            set{_IdPelicula = value;}
        }
    }
}