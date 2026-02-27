public interface IPostService
{
    Task<IEnumerable<PostResponseDto>> GetPostsAsync();
    Task<PostResponseDto> CreatePostAsync(Guid userId, PostRequestDto dto);
    Task UpdatePostAsync(Guid userId, Guid postId, PostRequestDto dto);
    Task DeletePostAsync(Guid userId, Guid postId);
}