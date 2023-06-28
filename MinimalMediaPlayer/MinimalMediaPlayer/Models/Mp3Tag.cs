using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MinimalMediaPlayer.Models
{
    internal class Mp3Tag
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Year { get; set; }
        public string Genere { get; set; }
        public string Comment { get; set; }
        public void Mp3Reader(string pathtofile)
        {
            TagLib.File tagFile = TagLib.File.Create(pathtofile);
            Title = tagFile.Tag.Title;
            Artist = tagFile.Tag.FirstAlbumArtist;
            Album = tagFile.Tag.Album;
            Year = Convert.ToString(tagFile.Tag.Year);
            Genere = tagFile.Tag.FirstGenre; // Genre List Update
            Comment = tagFile.Tag.Comment;
        }
    }
}
