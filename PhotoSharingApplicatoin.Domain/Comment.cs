namespace PhotoSharingApplication.Domain;

public class Comment
{
    public int Id { get; set; }
    public int PhotoId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Body { get; set; }
}
