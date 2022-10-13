using System;

namespace TP09_Arfa_Rozenbaum.Models
{ 
    public class Video
    {
        private int _IdVideo;
        private string _ArchivoVideo; 
        private int _IdPelicula;
        public Video(int IdVideo, string ArchivoVideo, int IdPelicula)
        {
            _IdVideo = IdVideo;
            _ArchivoVideo = ArchivoVideo;
            _IdPelicula = IdPelicula;
        }
        public Video(){}

        public int IdVideo
        {
            get {return _IdVideo;}
            set{_IdVideo = value;}
        }
        public string ArchivoVideo
        {
            get {return _ArchivoVideo;}
            set{_ArchivoVideo = value;}
        }
        public int IdPelicula
        {
            get {return _IdPelicula;}
            set{_IdPelicula = value;}
        }
    }
}