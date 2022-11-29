using System.ComponentModel.DataAnnotations;

namespace ClassRoomApi.Models;

public class CreateCourseDto
{
    [Required]
    public string? Name { get; set; }
}