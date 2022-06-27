namespace MusicInfo.Models
{
    public class TrackData
    {
        public string ArtistName { get; set; } = "";
        public string CollectionName { get; set; } = "";
        public string TrackName { get; set; } = "";
        public int? TrackId { get; set; }
        public string ArtworkUrl100 { get; set; } = "";
        public DateTime ReleaseDate { get; set; }
        public string PrimaryGenreName { get; set; } = "";
        public string PreviewUrl { get; set; } = "";
    }

    public class MusicInfoResults
    {
        public List<TrackData> Results { get; set; } = new List<TrackData>();
    }
}
