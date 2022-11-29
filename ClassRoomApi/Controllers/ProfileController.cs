using ClassRoomApi.Data;
using ClassRoomApi.Entities;
using ClassRoomApi.Mappers;
using ClassRoomApi.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassRoomApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProfileController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly AppDbContext _context;
    public ProfileController(UserManager<User> userManager, AppDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    [HttpGet("courses")]
    public async Task<IActionResult> GetCourses()
    {
        var user = await _userManager.GetUserAsync(User);
        var userCourseDto = user.Courses?.Select(uc => uc.Course.ToDto()).ToList();

        return Ok(userCourseDto);
    }

    [HttpGet("courses/{courseId}/tasks")]
    public async Task<IActionResult> GetUserTasks(Guid courseId)
    {
        var user = await _userManager.GetUserAsync(User);

        var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId
        && c.Users.Any(u => u.UserId == user.Id));

        if (course?.TaskEntities is null) return NotFound();

        var tasks = course.TaskEntities;
        var userTasks = new List<UserTaskResultDto>();

        foreach (var task in tasks)
        {
            var result = task.Adapt<UserTaskResultDto>();
            var userResultEntity = task.UserTasks.FirstOrDefault(t => t.UserId == user.Id);

            result.UserResult = userResultEntity is null ? null : new UserTaskResult()
            {
                Status = userResultEntity.Status,
                Description = userResultEntity.Description
            };

            userTasks.Add(result);
        }

        return Ok(userTasks);
    }

    [HttpPost("courses/{courseId}/tasks/{taskId}")]
    public async Task<IActionResult> AddUserTaskResult(Guid courseId, Guid taskId, [FromBody] CreateUserTaskResultDto resultDto)
    {
        var user = await _userManager.GetUserAsync(User);

        var task = await _context.TaskEntities.FirstOrDefaultAsync(tc => tc.CourseId == courseId && tc.Id == taskId
        && tc.Course.Users.Any(c => c.UserId == user.Id));
        if (task is null) return NotFound();


        var userTaskResult = await _context.UserTasks.FirstOrDefaultAsync(ut => ut.UserId == user.Id && ut.TaskId == task.Id);
        if (userTaskResult is null)
        {
            userTaskResult = new UserTask()
            {
                UserId = user.Id,
                TaskId = task.Id
            };

            await _context.AddAsync(userTaskResult);
        }

        userTaskResult.Status = resultDto.Status;
        userTaskResult.Description = resultDto.Description;

        await _context.SaveChangesAsync();

        return Ok();
    }

}
