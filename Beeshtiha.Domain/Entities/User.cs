using Beeshtiha.Domain.Commons;
using Beeshtiha.Domain.Enums;

namespace Beeshtiha.Domain.Entities;

public class User : Auditable
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public UserRole UserRole { get; set; }
}
