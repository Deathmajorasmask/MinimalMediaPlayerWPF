using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Custom libs
using MinimalMediaPlayer.Models;

namespace MinimalMediaPlayer.Controller
{
    internal class CtrlMusic
    {
        public Song song = new Song();
        Mp3Tag mp3Reader = new Mp3Tag();
        public CtrlMusic()
        {
            song.IDMusic = 0;
            song.Title = "";
            song.Artist = "";
            song.Album = "";
            song.Year = "";
            song.Genere = "";
            song.Comment = "";

        }

        public void AddSong(string pathtofile)
        {
            mp3Reader.Mp3Reader(pathtofile);
            song.IDMusic = 0;
            song.Title = mp3Reader.Title;
            song.Artist = mp3Reader.Artist;
            song.Album = mp3Reader.Album;
            song.Year = mp3Reader.Year;
            song.Genere = mp3Reader.Genere;
            song.Comment = mp3Reader.Comment;
        }

        public string getTitle()
        {
            return song.Title;
        }
    }
}
