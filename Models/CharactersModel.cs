namespace Softhouse_Test_App.Models
{
    public class Info
    {
        public int Count { get; set; }
        public int TotalPages { get; set; }
        public object PreviousPage { get; set; }
        public object NextPage { get; set; }
    }

    public class Character
    {
        public int _id { get; set; }
        public List<string> Films { get; set; }
        public List<string> ShortFilms { get; set; }
        public List<string> TvShows { get; set; }
        public List<string> VideoGames { get; set; }
        public List<string> ParkAttractions { get; set; }
        public List<object> Allies { get; set; }
        public List<object> Enemies { get; set; }
        public string SourceUrl { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Url { get; set; }
        public int __v { get; set; }
    }

    public class CharactersModel
    {
        public Info Info { get; set; }
        public List<Character> Data { get; set; }
    }

}

