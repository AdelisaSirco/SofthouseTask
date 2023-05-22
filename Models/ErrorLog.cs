namespace Softhouse_Test_App.Models
{
    public class ErrorLog
    {
       
            public int Id { get; set; }
            public string? ErrorMessage { get; set; }
            public string? StackTrace { get; set; }
            public DateTime? Timestamp { get; set; }
       
    }
}
