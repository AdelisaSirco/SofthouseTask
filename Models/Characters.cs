namespace Softhouse_Test_App.Models
{
    public class Characters
    {
     
            public int Id { get; set; }
            public List<string> Films { get; set; }
            public List<string> ShortFilms { get; set; }
            public List<string> TVShows { get; set; }     
            public string SourceUrl { get; set; }
            public string Name { get; set; }       
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        
          
        
    }

}

