using Microsoft.AspNetCore.Components;
using PhotoSharingApplication.Domain;

namespace PhotoSharingApplication.Client.Components;

public class CommentComponentBase : ComponentBase
{
    [Parameter] public Comment Comment { get; set; }
    protected Comment comment;
    
    [Parameter] public ViewMode ViewMode { get; set; } = ViewMode.View;
    [Parameter] public EventCallback<ViewMode> ViewModeChanged { get; set; }

    override protected void OnParametersSet()
    {
        comment = new Comment()
        {
            Id = Comment.Id,
            PhotoId = Comment.PhotoId,
            Title = Comment.Title,
            Body = Comment.Body
        };
    }

    protected async Task NotifyCommentStateChanged(ViewMode state) => await ViewModeChanged.InvokeAsync(state);
}
