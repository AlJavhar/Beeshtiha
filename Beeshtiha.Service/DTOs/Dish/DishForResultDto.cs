using Beeshtiha.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Beeshtiha.Service.DTOs.Dish;

public class DishForResultDto
{
    public int CreaterId { get; set; }
    public int Amount { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public Category Category { get; set; }
    public string Igredients { get; set; }
}
