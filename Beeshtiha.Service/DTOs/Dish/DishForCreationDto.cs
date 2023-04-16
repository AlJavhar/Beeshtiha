using Beeshtiha.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Beeshtiha.Service.DTOs.Dish;

public class DishForCreationDto
{
    [Required] 
    public int CreaterId { get; set; }
    [Required] 
    public int Amount { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    public string Description { get; set; }

    [Required(ErrorMessage = "Price is required")]
    public int Price { get; set; }
    public Category Category { get; set; }
    public string Igredients { get; set; }
}
