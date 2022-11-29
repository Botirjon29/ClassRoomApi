using ClassRoomApi.Entities;
using ClassRoomApi.Filter;
using ClassRoomApi.Mappers;
using ClassRoomApi.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassRoomApi.Controllers;
public partial class CoursesController : ControllerBase
{
    [HttpPost("{courseId}/tasks")]
    [ProducesResponseType(typeof(TaskDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddTask(Guid courseId, [FromBody] CreateTaskDto createTaskDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        var user = await _userManager.GetUserAsync(User);

        var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId
        && c.Users.Any(u => u.UserId == user.Id && u.IsAdmin));
        if (course is null) return NotFound();

        var task = createTaskDto.Adapt<TaskEntity>();
        task.CreatedDate = DateTime.Now;
        task.CourseId = course.Id;

        await _context.TaskEntities.AddAsync(task);
        await _context.SaveChangesAsync();

        return Ok(task.Adapt<TaskDto>());
    }

    [HttpGet("{courseId}/tasks")]
    [ProducesResponseType(typeof(TaskDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTasks(Guid courseId)
    {
        var user = await _userManager.GetUserAsync(User);

        var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId
        && c.Users.Any(u => u.UserId == user.Id));
        if (course is null) return NotFound();

        var tasks = course.TaskEntities?.Select(task => task.Adapt<TaskDto>()).ToList();

        return Ok(tasks);
    }

    [HttpGet("{courseId}/tasks/{taskId}")]
    [ProducesResponseType(typeof(TaskDto), StatusCodes.Status200OK)]
    [IsCourseUserOrAdmin]
    public async Task<IActionResult> GetTaskById(Guid courseId, Guid taskId)
    {
        var user = await _userManager.GetUserAsync(User);

        var task = await _context.TaskEntities.FirstOrDefaultAsync(t => t.CourseId == courseId && t.Id == taskId
        && t.Course.Users.Any(cu => cu.UserId == user.Id));

        if (task is null) return NotFound();

        return Ok(task.Adapt<TaskDto>());
    }

    [HttpPut("{courseId}/tasks/{taskId}")]
    [ProducesResponseType(typeof(TaskDto), StatusCodes.Status200OK)]
    [IsCourseUserOrAdmin(true)]
    public async Task<IActionResult> UpdateTask(Guid courseId, Guid taskId, [FromBody] UpdateTaskDto updateTaskDto)
    {
        var user = await _userManager.GetUserAsync(User);

        var task = await _context.TaskEntities.FirstOrDefaultAsync(t => t.CourseId == courseId && t.Id == taskId
        && t.Course.Users.Any(cu => cu.UserId == user.Id && cu.IsAdmin));

        if (task is null) return NotFound();

        task.SetValues(updateTaskDto);

        await _context.SaveChangesAsync();

        return Ok(task.Adapt<UpdateTaskDto>());
    }

    [HttpDelete("{courseId}/tasks/{taskId}")]
    public async Task<IActionResult> DeleteTask(Guid courseId, Guid taskId)
    {
        var user = await _userManager.GetUserAsync(User);

        var task = await _context.TaskEntities.FirstOrDefaultAsync(t => t.CourseId == courseId && t.Id == taskId
        && t.Course.Users.Any(cu => cu.UserId == user.Id && cu.IsAdmin));

        if (task is null) return NotFound();

        _context.TaskEntities.Remove(task);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpGet("{courseId}/tasks/{taskId}/results")]
    [ProducesResponseType(typeof(UserTaskResultDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTaskResults(Guid courseId, Guid taskId)
    {
        var task = await _context.TaskEntities.FirstOrDefaultAsync(t => t.Id == taskId && t.CourseId == courseId);
        if (task is null) return NotFound();

        var taskDto = task.Adapt<UsersTaskResultsDto>();

        if (task.UserTasks is null) return Ok(taskDto);

        foreach (var result in task.UserTasks)
        {
            taskDto.UsersResult ??= new List<UsersTaskResult>();
            taskDto.UsersResult.Add(result.Adapt<UsersTaskResult>());
        }

        return Ok(taskDto);
    }

    [HttpPut("{courseId}/tasks/{taskId}/resultId/{resultId}")]
    [ProducesResponseType(typeof(UsersTaskResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> CheckUserResult(Guid courseId, Guid taskId, Guid resultId, CreateUserTaskResultDto resultDto)
    {
        var task = await _context.TaskEntities.FirstOrDefaultAsync(t => t.Id == taskId && t.CourseId == courseId);
        if (task is null) return NotFound();

        var result = task.UserTasks?.FirstOrDefault(ut => ut.Id == resultId);
        if (result is null) return NotFound();

        result.Status = resultDto.Status;
        result.Description = resultDto.Description;

        await _context.SaveChangesAsync();

        return Ok(result.Adapt<UsersTaskResult>());
    }
}
