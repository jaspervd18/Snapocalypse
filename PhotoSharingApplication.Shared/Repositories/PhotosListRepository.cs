//using PhotoSharingApplication.Domain;
//using PhotoSharingApplication.Shared.Interfaces;

//namespace PhotoSharingApplication.Shared.Repositories;

//public class PhotosListRepository : IPhotosRepository
//{
//    private readonly List<Photo> photos = [];
//    public PhotosListRepository()
//    {
//    }

//    public IEnumerable<Photo> GetPhotos()
//    {
//        return photos;
//    }

//    public Photo? GetPhotoById(int id)
//    {
//        return photos.FirstOrDefault(p => p.Id == id);
//    }

//    public void AddPhoto(Photo newPhoto)
//    {
//        newPhoto.Id = photos.Any() ? photos.Max(p => p.Id) + 1 : 1;
//        photos.Add(newPhoto);

//        Console.WriteLine(newPhoto.ImageMimeType);
//        Console.WriteLine(newPhoto.DataUrl);

//    }

//    public void RemovePhoto(int id)
//    {
//        Photo? photo = photos.FirstOrDefault(p => p.Id == id);
//        if (photo is not null)
//            photos.Remove(photo);
//    }

//    public void UpdatePhoto(Photo photo)
//    {
//        var photoToUpdate = photos.FirstOrDefault(p => p.Id == photo.Id);
//        if (photoToUpdate is null)
//            return;
//        photoToUpdate.Title = photo.Title;
//        photoToUpdate.Description = photo.Description;
//        photoToUpdate.PhotoFile = photo.PhotoFile;
//        photoToUpdate.ImageMimeType = photo.ImageMimeType;
//    }
//}
