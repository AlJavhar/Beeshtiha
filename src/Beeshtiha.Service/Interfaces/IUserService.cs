using Beeshtiha.Domain.Configurations;
using Beeshtiha.Domain.Entities;
using Beeshtiha.Service.DTOs.Dish;
using Beeshtiha.Service.DTOs.User;
using System.Linq.Expressions;

namespace Beeshtiha.Service.Interfaces;

public interface IUserService
{
    ValueTask<UserForResultDto> AddCardAsync(UserForCreationDto dto);
    ValueTask<IEnumerable<UserForResultDto>> GetAllAsync(PaginationParams @params);
    ValueTask<bool> RemoveAsync(Expression<Func<User, bool>> predicate);
    ValueTask<UserForResultDto> UpdateAsync(int id, UserForCreationDto dto);
    ValueTask<UserForResultDto> GetByAsync(Expression<Func<User, bool>> predicate);
}
