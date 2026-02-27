public record PostRequestDto(string Title, string Category, string Content);
public record PostResponseDto(Guid Id, string Title, string Category, string Content, Guid UserId, DateTime CreatedAt);