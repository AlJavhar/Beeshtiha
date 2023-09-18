using Beeshtiha.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Beeshtiha.Service.DTOs.User;

public class UserForCreationDto
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Phone is required")]
    public string Phone { get; set; }
    public UserRole UserRole { get; set; }
}
