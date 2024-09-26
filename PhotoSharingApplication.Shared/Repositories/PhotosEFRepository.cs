using Microsoft.EntityFrameworkCore;
using PhotoSharingApplication.Domain;
using PhotoSharingApplication.Persistence.Data;
using PhotoSharingApplication.Shared.Interfaces;

namespace PhotoSharingApplication.Shared.Repositories;

public class PhotosEFRepository : IPhotosRepository
{
    private readonly PhotosDbContext context;

    public PhotosEFRepository(PhotosDbContext context)
    {
        this.context = context;
    }

    public async Task<Photo> AddPhotoAsync(Photo photo)
    {
        // The AddPhotoAsync method should add the photo parameter to the
        // Photos property of the DbContext, then save the changes.
        context.Photos.Add(photo);
        await context.SaveChangesAsync();
        return photo;
    }

    public async Task<Photo?> DeletePhotoAsync(int id)
    {
        // The DeletePhotoAsync method should find the photo by its ID,
        // delete it if found, and save the changes.
        Photo? photo = await context.Photos.FirstOrDefaultAsync(p => p.Id == id);
        if (photo is not null)
        {
            context.Photos.Remove(photo);
            await context.SaveChangesAsync();
        }
        return photo;
    }

    public async Task<Photo?> GetPhotoByIdAsync(int id)
    {
        return await context.Photos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Photo>> GetPhotosAsync()
    {
        // The GetPhotosAsync method should return all photos from the database.
        return await context.Photos.AsNoTracking().ToListAsync();
    }

    public async Task UpdatePhotoAsync(Photo photo)
    {
        // The UpdatePhotoAsync method should mark the photo entity as
        // modified and save changes to the database.
        context.Entry(photo).State = EntityState.Modified;
        context.Photos.Update(photo);
        await context.SaveChangesAsync();
    }
}
