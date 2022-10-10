using System;

namespace TP09_Arfa_Rozenbaum.Models
{ 
    public class Video
    {
        private int _IdVideo;
        private string _Video; 
        private int _IdPelicula;
        public Video(int IdVideo, string Video, int IdPelicula)
        {
            _IdVideo = IdVideo;
            _Video = Video;
            _IdPelicula = IdPelicula;
        }
        public Video(){}

        public int IdVideo
        {
            get {return _IdVideo;}
            set{_IdVideo = value;}
        }
        public string Video
        {
            get {return _Video;}
            set{_Video = value;}
        }
        public int IdPelicula
        {
            get {return _IdPelicula;}
            set{_IdPelicula = value;}
        }
    }
}