using Microsoft.EntityFrameworkCore;
using RegisterFormApp.Models;

namespace RegisterFormApp.Data;

public class RegisterFormDbContext : DbContext
{
    public RegisterFormDbContext(DbContextOptions<RegisterFormDbContext> options)
        : base(options)
    {
    }

    public DbSet<Register> Registers { get; set; }
}
