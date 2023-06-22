using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Custom libs
using WPFPlayMusic.Models;

namespace WPFPlayMusic.Controller
{
    internal class CtrlMusic
    {
        Song song = new Song();
        public CtrlMusic()
        {
            song.IDMusic = 0;
            song.SName = "";
            song.SArtist = "";
            song.SDuracion = "";
            song.SGenero = "";
            song.SGenero = "";
        }

        public void AddSong(string SName, string SArtist, string SDuracion, string SGenero)
        {
            song.IDMusic = 1;
            song.SName = SName;
            song.SArtist = SArtist;
            song.SDuracion = SDuracion;
            song.SGenero = SGenero;
        }

        public void playSong()
        {

        }

        public void pauseSong()
        {
            // TODO
        }

        public void stopSong()
        {
            // TODO
        }

        public void nextSong()
        {
            // TODO
        }

        public void skipSong()
        {
            // TODO
        }

        private void loadSong()
        {
            // TODO
        }
    }
}
