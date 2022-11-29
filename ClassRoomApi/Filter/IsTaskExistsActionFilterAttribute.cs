using ClassRoomApi.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace ClassRoomApi.Filter;

public class IsTaskExistsActionFilterAttribute : ActionFilterAttribute
{
    private readonly AppDbContext _context;

    public IsTaskExistsActionFilterAttribute(AppDbContext context)
    {
        _context = context;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ActionArguments.ContainsKey("taskId"))
        {
            await next();
            return;
        }

        var taskId = (Guid?)context.ActionArguments["taskId"];

        if (!await _context.TaskEntities.AnyAsync(t => t.Id == taskId))
        {
            await next();
            return;
        }

        await next();
    }
}
