using ClassRoomApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace ClassRoomApi.Filter;

public class IsCourseExistsActionFilterAttribute : ActionFilterAttribute
{
    private readonly AppDbContext _context;

    public IsCourseExistsActionFilterAttribute(AppDbContext context)
    {
        _context = context;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ActionArguments.ContainsKey("courseId"))
        {
            await next();
            return;
        }

        var courseId = (Guid)context.ActionArguments["courseId"];
        if (!await _context.Courses.AnyAsync(c => c.Id == courseId))
        {
            context.Result = new NotFoundResult();
            return;
        }

        await next();
    }
}
