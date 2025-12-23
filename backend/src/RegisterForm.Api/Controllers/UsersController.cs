using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterForm.Api.Data;
using RegisterForm.Api.DTOs;
using RegisterForm.Api.Models;

namespace RegisterForm.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public UsersController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Create (CreateUserRequest request)
    {
        var newUser = new AppUser
        {
            Name = request.Name,
            BirthDate = request.BirthDate!.Value,
            City = request.City,
            State = request.State,
            Email = request.Email
        };

        _dbContext.Add(newUser);
        await _dbContext.SaveChangesAsync();

        var userData = new UserResponse
        {
            Id = newUser.Id,
            Name = newUser.Name,
            BirthDate = newUser.BirthDate,
            City = newUser.City,
            State = newUser.State,
            Email = newUser.Email
        };

        return CreatedAtAction(nameof(GetById), new { id = userData.Id }, userData);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GetById(int id)
    {
        var response = await _dbContext.Users
            .Where(u => u.Id == id)
            .Select(u => new UserResponse 
            { 
                Id = u.Id,
                Name = u.Name,
                BirthDate = u.BirthDate,
                City = u.City,
                State = u.State,
                Email = u.Email
            })
            .SingleOrDefaultAsync();

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    } 
}
