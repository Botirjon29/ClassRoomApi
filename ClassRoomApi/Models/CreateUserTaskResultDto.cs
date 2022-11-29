using ClassRoomApi.Entities;

namespace ClassRoomApi.Models;

public class CreateUserTaskResultDto
{
    public string? Description { get; set; }
    public EUserTaskStatus Status { get; set; }
}
