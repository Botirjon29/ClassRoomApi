using System.ComponentModel.DataAnnotations;

namespace ClassRoomApi.Entities;

public class LocalizedStringEntity
{
    [Key]
    public string? Key { get; set; } // user-topilmadi
    public string? Uz { get; set; } // Foydalanuvchi topilmadi
    public string? Ru { get; set; } // polzavatel ne naydina
    public string? En { get; set; } // user not found
}
