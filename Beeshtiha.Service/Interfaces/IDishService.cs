using Beeshtiha.Domain.Configurations;
using Beeshtiha.Domain.Entities;
using Beeshtiha.Service.DTOs.Card;
using Beeshtiha.Service.DTOs.Dish;
using System.Linq.Expressions;

namespace Beeshtiha.Service.Interfaces;

public interface IDishService
{
    ValueTask<DishForResultDto> AddCardAsync(DishForCreationDto dto);
    ValueTask<IEnumerable<DishForResultDto>> GetAllAsync(PaginationParams @params);
    ValueTask<bool> RemoveAsync(Expression<Func<Dish, bool>> predicate);
    ValueTask<DishForResultDto> UpdateAsync(int id, DishForCreationDto dto);
    ValueTask<DishForResultDto> GetByAsync(Expression<Func<Dish, bool>> predicate);
}
