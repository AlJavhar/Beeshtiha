using Beeshtiha.Domain.Enums;

namespace Beeshtiha.Service.DTOs.User;

public class UserForResultDto
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public UserRole UserRole { get; set; }
}
