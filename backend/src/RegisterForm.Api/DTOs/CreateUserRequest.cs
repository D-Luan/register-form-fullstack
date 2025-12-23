using System.ComponentModel.DataAnnotations;

namespace RegisterForm.Api.DTOs;

public record CreateUserRequest(
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name must be 100 characters or less")]
    string Name,

    [Required(ErrorMessage = "The date is required")]
    DateOnly? BirthDate,

    [Required(ErrorMessage = "The city is required")]
    [StringLength(100, ErrorMessage = "City must be 100 characters or less")]
    string City,

    [Required(ErrorMessage = "The state address is required")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "State abbreviation must be exactly 2 characters")]
    string State,

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [StringLength(150, ErrorMessage = "Email is too long")]
    string Email
);
