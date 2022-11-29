using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClassRoomApi.Filter;

public class IsCourseUserOrAdminAttribute : TypeFilterAttribute
{
	public IsCourseUserOrAdminAttribute(bool onlyAdmin = false) : base(typeof(CourseAdminFilterAttribute))
	{
		Arguments = new object[] { onlyAdmin };
	}
}
