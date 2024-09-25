using Microsoft.AspNetCore.Components;
using PhotoSharingApplication.Domain;
using PhotoSharingApplication.Shared.Interfaces;

namespace PhotoSharingApplication.Components.Pages.Photos;

public partial class Details
{
    [Inject] IPhotosRepository PhotosRepository { get; set; } = default!;
    [Inject] NavigationManager NavigationManager { get; set; } = default!;
    [Parameter] public int Id { get; set; }
    Photo? photo = new Photo() { Title = "new photo"};

    protected override async Task OnInitializedAsync()
    {
        photo = await PhotosRepository.GetPhotoByIdAsync(Id);
        if (photo == null)
        {
            NavigationManager.NavigateTo("/photos/all");
        }
    }
}
