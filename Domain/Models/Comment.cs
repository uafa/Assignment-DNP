namespace Domain;

public class Comment
{
    public string UserId { get; set; }
    public long PostId { get; set; }
    public string Body { get; set; }

    public Comment(string userId, long postId, string body)
    {
        UserId = userId;
        PostId = postId;
        Body = body;
    }
}