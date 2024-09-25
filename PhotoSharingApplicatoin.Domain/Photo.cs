namespace PhotoSharingApplication.Domain;

public class Photo
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public byte[]? PhotoFile { get; set; }
    public string? ImageMimeType { get; set; }
    public string? DataUrl => PhotoFile == null ? null : $"data:{ImageMimeType};base64,{Convert.ToBase64String(PhotoFile)}";
}
