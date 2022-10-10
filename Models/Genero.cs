using System;

namespace TP09_Arfa_Rozenbaum.Models
{ 
    public class Genero
    {
        private int _IdGenero;
        private string _Genero;
        public Genero(int IdGenero, string Genero)
        {
            _IdGenero = IdGenero;
            _Genero = Genero;
        }
        public Genero(){}

        public int IdGenero
        {
            get {return _IdGenero;}
            set{_IdGenero = value;}
        }
        public string  Genero
        {
            get {return _Genero;}
            set{_Genero = value;}
        }
    }
}