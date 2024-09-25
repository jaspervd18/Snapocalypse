using Microsoft.AspNetCore.Components;
using PhotoSharingApplication.Domain;
using PhotoSharingApplication.Shared.Interfaces;

namespace PhotoSharingApplication.Components.Pages.Photos;

public partial class AllPhotos
{
    [Inject] IPhotosRepository PhotosRepository { get; set; } = default!;
    [Inject] NavigationManager NavigationManager { get; set; } = default!;
    IEnumerable<Photo> photos = new List<Photo>();

    protected override async Task OnInitializedAsync()
    {
        photos = await PhotosRepository.GetPhotosAsync();
    }
}