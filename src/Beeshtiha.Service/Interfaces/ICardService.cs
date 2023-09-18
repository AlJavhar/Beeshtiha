using Beeshtiha.Domain.Configurations;
using Beeshtiha.Domain.Entities;
using Beeshtiha.Service.DTOs.Card;
using System.Linq.Expressions;

namespace Beeshtiha.Service.Interfaces;

public interface ICardService
{
    ValueTask<CardForResultDto> AddCardAsync(CardForCreationDto dto);
    ValueTask<IEnumerable<CardForResultDto>> GetAllAsync(PaginationParams @params);
    ValueTask<bool> RemoveAsync(Expression<Func<Card, bool>> predicate); 
    ValueTask<CardForResultDto> UpdateAsync(int id, CardForCreationDto dto);
    ValueTask<CardForResultDto> GetByAsync(Expression<Func<Card, bool>> predicate);
}
