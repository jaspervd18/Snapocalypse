using Microsoft.EntityFrameworkCore;
using PhotoSharingApplication.Domain;
using PhotoSharingApplication.Shared.Interfaces;
using PhotoSharingApplication.Shared.Data;

namespace PhotoSharingApplication.Shared.Repositories;

public class CommentsRepository : ICommentsRepository
{
    private readonly IDbContextFactory<PhotosDbContext> _contextFactory;

    public CommentsRepository(IDbContextFactory<PhotosDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<Comment> AddCommentAsync(Comment comment)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Comments.Add(comment);
        await context.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment?> GetCommentByIdAsync(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Comments.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Comment>> GetCommentsForPhotoAsync(int photoId)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Comments.AsNoTracking().Where(c => c.PhotoId == photoId).ToListAsync();
    }

    public async Task DeleteCommentAsync(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        Comment? comment = await context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        if (comment is not null)
        {
            context.Comments.Remove(comment);
            await context.SaveChangesAsync();
        }
    }

    public async Task<Comment> UpdateCommentAsync(Comment comment)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Comments.Update(comment);
        await context.SaveChangesAsync();
        return comment;
    }
}