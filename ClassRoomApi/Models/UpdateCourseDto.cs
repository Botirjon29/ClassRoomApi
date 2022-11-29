using System.ComponentModel.DataAnnotations;

namespace ClassRoomApi.Models;

public class UpdateCourseDto
{
    [Required]
    public string? Name { get; set; }
}