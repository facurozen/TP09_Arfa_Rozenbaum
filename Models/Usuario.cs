using System;

namespace TP09_Arfa_Rozenbaum.Models
{ 
    public class Usuario
    {
        private int _IdUsuario; 
        private string _Nombre;
        private string _Email;
        private string _Contraseña;
        public Usuario(int IdUsuario, string Nombre, string Email, string Contraseña)
        {
            _IdUsuario = IdUsuario;
            _Nombre = Nombre;
            _Email = Email;
            _Contraseña = Contraseña;
        }
        public Usuario(){}

         public int IdUsuario
        {
            get {return _IdUsuario;}
            set{_IdUsuario = value;}
        }
        public string Nombre
        {
            get {return _Nombre;}
            set{_Nombre = value;}
        }
        public string Email
        {
            get {return _Email;}
            set{_Email = value;}
        }
        public string Contraseña
        {
            get {return _Contraseña;}
            set{_Contraseña = value;}
        }
    }
}