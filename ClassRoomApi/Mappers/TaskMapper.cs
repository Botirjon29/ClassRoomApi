using ClassRoomApi.Entities;
using ClassRoomApi.Models;

namespace ClassRoomApi.Mappers;

public static class TaskMapper
{
    public static void SetValues(this TaskEntity task, UpdateTaskDto updateTaskDto)
    {
        task.Title = updateTaskDto.Title;
        task.Description = updateTaskDto.Description;
        task.StartDate = updateTaskDto.StartDate;
        task.EndDate = updateTaskDto.EndDate;
        task.MaxScore = updateTaskDto.MaxScore;
        task.Status = updateTaskDto.Status;
    }
}
