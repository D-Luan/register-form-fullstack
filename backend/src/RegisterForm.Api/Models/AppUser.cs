using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterForm.Api.Models;

public class AppUser
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public DateOnly BirthDate { get; set; }

    [MaxLength(100)]
    public string City { get; set; } = string.Empty;

    [Column(TypeName="char(2)")]
    public string State { get; set; } = string.Empty;

    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;
}
