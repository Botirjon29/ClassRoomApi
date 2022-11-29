using ClassRoomApi.Entities;
using ClassRoomApi.Models;
using ClassRoomApi.Services;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassRoomApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ILogger<AccountController> _logger;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AccountController> logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(SignUpUserDto userDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        if (userDto.Password != userDto.ConfirmPassword) return BadRequest();

        if (await _userManager.Users.AnyAsync(u => u.UserName == userDto.UserName)) return NotFound();

        var user = userDto.Adapt<User>();

        await _userManager.CreateAsync(user, userDto.Password);

        _logger.LogInformation("User saved to database with id {0}", user.Id);

        await _signInManager.SignInAsync(user, isPersistent: true);

        _logger.LogInformation("User registered");

        return Ok();
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SignIn(SignInUserDto userDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        if (!await _userManager.Users.AnyAsync(u => u.UserName == userDto.UserName)) return NotFound();

        var result = await _signInManager.PasswordSignInAsync(userDto.UserName, userDto.Password, isPersistent: true, true);
        if (!result.Succeeded) return BadRequest();

        return Ok();
    }

    [HttpGet("{userName}")]
    [Authorize]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Profile(string userName)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user.UserName != userName) return NotFound();

        var userDto = user.Adapt<UserDto>();

        _logger.LogInformation("User profile with id {0}", user.Id);

        return Ok(userDto);
    }

    [HttpGet("localize")]
    public IActionResult GetString([FromServices] LocalizerService localizerService)
    {
        //return Ok(localizerService.GetLocalizedString("Required"));
        return Ok(localizerService["Required"]);
    }
}
