using Beeshtiha.Domain.Commons;
using Beeshtiha.Domain.Enums;

namespace Beeshtiha.Domain.Entities;

public class Dish : Auditable
{
    public int CreaterId { get; set; }
    public User User { get; set; }

    public int Amount { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public Category Category { get; set; }
    public string Igredients { get; set; }
}
