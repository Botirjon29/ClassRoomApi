using ClassRoomApi.Entities;
using ClassRoomApi.Models;
using Mapster;

namespace ClassRoomApi.Mappers;

public static class CourseMapper
{
    public static CourseDto ToDto(this Course course)
    {
        return new CourseDto
        {
            Id = course.Id,
            Name = course.Name,
            Key = course.Key,
            Users = course.Users?.Select(userCourse => userCourse.User?.Adapt<UserDto>()).ToList()
        };
    }
}