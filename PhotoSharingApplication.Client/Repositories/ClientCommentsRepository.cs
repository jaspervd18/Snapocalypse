using PhotoSharingApplication.Domain;
using PhotoSharingApplication.Shared.Interfaces;
using System.Net.Http.Json;

namespace PhotoSharingApplication.Client.Repositories;
public class ClientCommentsRepository(HttpClient _httpClient) : ICommentsRepository
{
    public async Task<Comment> AddCommentAsync(Comment comment)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/comments", comment);
        return await response.Content.ReadFromJsonAsync<Comment>();
    }
    public async Task DeleteCommentAsync(int id)
    {   
        await _httpClient.DeleteAsync($"api/comments/{id}");
    }
    public async Task<Comment?> GetCommentByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Comment>($"api/comments/{id}");
    }
    public async Task<List<Comment>> GetCommentsForPhotoAsync(int photoId)
    {
        return await _httpClient.GetFromJsonAsync<List<Comment>>($"api/photos/{photoId}/comments");
    }
    public async Task<Comment> UpdateCommentAsync(Comment comment)
    {
        HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/comments/{comment.Id}", comment);
        return await response.Content.ReadFromJsonAsync<Comment>();
    }
}
