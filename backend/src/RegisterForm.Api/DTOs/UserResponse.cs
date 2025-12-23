namespace RegisterForm.Api.DTOs;

public record UserResponse
{
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public DateOnly BirthDate { get; init; }
    public string City { get; init; } = default!;
    public string State { get; init; } = default!;
    public string Email { get; init; } = default!;
}
