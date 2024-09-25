using PhotoSharingApplication.Domain;

namespace PhotoSharingApplication.Shared.Interfaces;

public interface ICommentsRepository
{
    Task<Comment> AddCommentAsync(Comment comment);
    Task DeleteCommentAsync(int id);
    Task<Comment?> GetCommentByIdAsync(int id);
    Task<List<Comment>> GetCommentsForPhotoAsync(int photoId);
    Task<Comment> UpdateCommentAsync(Comment comment);
}
