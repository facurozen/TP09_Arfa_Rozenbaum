using System;

namespace TP09_Arfa_Rozenbaum.Models
{ 
    public class Pelicula
    {
        private int _IdPelicula; 
        private string _Nombre;
        private string _Portada;
        private string _Sinopsis;
        private TimeSpan _Duracion;
        private int _Año; 
        private int _IdGenero; 
        private int _CantLikes; 
        private string _SrcTrailer;

        public Pelicula(int IdPelicula, string Nombre, string Portada, string Sinopsis, TimeSpan Duracion, int Año, int IdGenero, int CantLikes, string SrcTrailer)
        {
            _IdPelicula = IdPelicula;
            _Nombre = Nombre;
            _Portada = Portada;
            _Sinopsis = Sinopsis;
            _Duracion = Duracion;
            _Año = Año;
            _IdGenero = IdGenero;
            _CantLikes = CantLikes;
            _SrcTrailer=SrcTrailer;
        }
        public Pelicula(){}

         public int IdPelicula
        {
            get {return _IdPelicula;}
            set{_IdPelicula = value;}
        }
        public string Nombre
        {
            get {return _Nombre;}
            set{_Nombre = value;}
        }
        public string Portada
        {
            get {return _Portada;}
            set{_Portada = value;}
        }
        public string Sinopsis
        {
            get {return _Sinopsis;}
            set{_Sinopsis = value;}
        }
        public TimeSpan Duracion
        {
            get {return _Duracion;}
            set{_Duracion = value;}
        }
        public int Año
        {
            get {return _Año;}
            set{_Año = value;}
        }
        public int IdGenero
        {
            get {return _IdGenero;}
            set{_IdGenero = value;}
        }
        public int CantLikes
        {
            get {return _CantLikes;}
            set{_CantLikes = value;}
        }
        public string SrcTrailer
        {
            get{return _SrcTrailer;}
            set{_SrcTrailer=value;}
        }
    }
}