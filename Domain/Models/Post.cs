using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Post
{
    public User User { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public int PostId { get; set; }
    
    public DateTime TimeStamp { get; set; }

    public Post(User user, string title, string body)
    {
        User = user;
        Title = title;
        Body = body;
    }
}