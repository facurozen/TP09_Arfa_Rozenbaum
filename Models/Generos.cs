using System;

namespace TP09_Arfa_Rozenbaum.Models
{ 
    public class Generos
    {
        private int _IdGenero;
        private string _Genero;
        public Generos(int IdGenero, string Genero)
        {
            _IdGenero = IdGenero;
            _Genero = Genero;
        }
        public Generos(){}

        public int IdGenero
        {
            get {return _IdGenero;}
            set{_IdGenero = value;}
        }
        public string Genero
        {
            get {return _Genero;}
            set{_Genero = value;}
        }
    }
}