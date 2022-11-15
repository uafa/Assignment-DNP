using System.Text.Json.Serialization;

namespace Domain;

public class User
{
    public string Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    
    [JsonIgnore]
    public ICollection<Post> Posts { get; set; }
    
    
}