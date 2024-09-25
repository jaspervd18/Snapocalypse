using Microsoft.AspNetCore.Components;
using PhotoSharingApplication.Domain;
using PhotoSharingApplication.Shared.Interfaces;

namespace PhotoSharingApplication.Client.Pages;

public partial class Comments
{
    [Inject] public ICommentsRepository CommentsRepository { get; set; }
    [Parameter] public int PhotoId { get; set; }
    private List<Comment> comments = default!;
    public Comment newComment;

    protected override async Task OnInitializedAsync()
    {
        newComment = new Comment() { PhotoId = PhotoId };
        comments = await CommentsRepository.GetCommentsForPhotoAsync(PhotoId);
    }

    private async Task UpdateComment(Comment comment)
    {
        await CommentsRepository.UpdateCommentAsync(comment);
        comments = await CommentsRepository.GetCommentsForPhotoAsync(PhotoId);
    }

    private async Task AddComment(Comment comment)
    {
        await CommentsRepository.AddCommentAsync(comment);
        newComment = new Comment() { PhotoId = PhotoId };
        comments = await CommentsRepository.GetCommentsForPhotoAsync(PhotoId);
    }

    private async Task DeleteComment(Comment comment)
    {
        await CommentsRepository.DeleteCommentAsync(comment.Id);
        comments = await CommentsRepository.GetCommentsForPhotoAsync(PhotoId);
    }
}
