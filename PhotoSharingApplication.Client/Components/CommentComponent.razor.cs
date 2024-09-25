using Microsoft.AspNetCore.Components;
using PhotoSharingApplication.Domain;

namespace PhotoSharingApplication.Client.Components;

public partial class CommentComponent
{
    [Parameter] public ViewMode ViewMode { get; set; }
    private ViewMode viewMode;

    [Parameter] public Comment? Comment { get; set; }
    private Comment? comment;

    [Parameter] public EventCallback<Comment> OnSave { get; set; }
    [Parameter] public EventCallback<Comment> OnDelete { get; set; }

    protected override void OnParametersSet()
    {
        viewMode = ViewMode;
        comment = new Comment() { Id = Comment.Id, PhotoId = Comment.PhotoId, Title = Comment.Title, Body = Comment.Body };
    }
}
