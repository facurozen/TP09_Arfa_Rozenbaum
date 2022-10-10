using System;

namespace TP09_Arfa_Rozenbaum.Models
{ 
    public class Pelicula
    {
        private int _IdPelicula; 
        private string _Nombre;
        private string _Portada;
        private string _Sinopsis;
        private DateTime _Duracion;
        private int _Año; 
        public Pelicula(int IdPelicula, string Nombre, string Portada, string Sinopsis, DateTime Duracion, int Año)
        {
            _IdPelicula = IdPelicula;
            _Nombre = Nombre;
            _Portada = Portada;
            _Sinopsis = Sinopsis;
            _Duracion = Duracion;
            _Año = Año;
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
        public DateTime Duracion
        {
            get {return _Duracion;}
            set{_Duracion = value;}
        }
        public int Año
        {
            get {return _Año;}
            set{_Año = value;}
        }
    }
}