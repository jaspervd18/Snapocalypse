using Microsoft.AspNetCore.Components;
using PhotoSharingApplication.Domain;
using PhotoSharingApplication.Shared.Interfaces;

namespace PhotoSharingApplication.Components.Pages.Photos;

public partial class CreateEditPhoto
{
    [Inject] IPhotosRepository PhotosRepository { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }
    [Parameter] public int? Id { get; set; }
    [SupplyParameterFromForm(FormName = "PhotoForm")] Photo? photo { get; set; } = new();
    [SupplyParameterFromForm(FormName = "PhotoForm")] FileModel? fileModel { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (Id.HasValue)
        {
            photo = await PhotosRepository.GetPhotoByIdAsync(Id.Value);
        }
        else
        {
            photo ??= new Photo() { Title = "New Photo" };
        }
        fileModel ??= new FileModel();
    }

    async Task Save()
    {
        if (photo is not null)
        {
            if (fileModel?.File is not null)
            {
                using var memoryStream = new MemoryStream();
                await fileModel.File.OpenReadStream().CopyToAsync(memoryStream);
                photo.PhotoFile = memoryStream.ToArray();
                photo.ImageMimeType = fileModel.File.ContentType;
            }
            if (photo.Id == 0)
            {
                await PhotosRepository.AddPhotoAsync(photo);
            }
            else
            {
                await PhotosRepository.UpdatePhotoAsync(photo);
            }
        }
        NavigationManager.NavigateTo("photos/all");
    }
}

class FileModel
{
    public IFormFile? File { get; set; }
}
