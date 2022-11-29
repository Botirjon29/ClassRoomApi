using System.ComponentModel.DataAnnotations;

namespace ClassRoomApi.Models;

public class CreateTaskCommentDto
{
    [Required]
    public string? Comment { get; set; }
    public Guid? ParentId { get; set; }
}
