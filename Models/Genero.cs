using System;

namespace TP09_Arfa_Rozenbaum.Models
{ 
    public class Genero
    {
        private int _IdGenero;
        private string _NombreGenero;
        public Genero(int IdGenero, string NombreGenero)
        {
            _IdGenero = IdGenero;
            _NombreGenero = NombreGenero;
        }
        public Genero(){}

        public int IdGenero
        {
            get {return _IdGenero;}
            set{_IdGenero = value;}
        }
        public string NombreGenero
        {
            get {return _NombreGenero;}
            set{_NombreGenero = value;}
        }
    }
}