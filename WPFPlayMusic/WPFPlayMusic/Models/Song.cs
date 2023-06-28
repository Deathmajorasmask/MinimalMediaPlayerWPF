namespace WPFPlayMusic.Models
{
    internal class Song
    {
		public int IDMusic { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Year { get; set; }
        public string Genere { get; set; }
        public string Comment { get; set; }
    }
}