using AutoMapper;
using beeshtiha.DAL.IRepositories;
using Beeshtiha.Domain.Configurations;
using Beeshtiha.Domain.Entities;
using Beeshtiha.Service.DTOs.Card;
using Beeshtiha.Service.Exeptions;
using Beeshtiha.Service.Extentions;
using Beeshtiha.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Beeshtiha.Service.Services;

public class CardService : ICardService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mappers;

    public CardService(IUnitOfWork unitOfWork, IMapper mappers)
    {
        this.unitOfWork = unitOfWork;
        this.mappers = mappers;
    }
    public async ValueTask<CardForResultDto> AddCardAsync(CardForCreationDto dto)
    {
        var card = await this.unitOfWork.Cards.SelectAsync(x => x.CustomerId == dto.CustomerId);
        if (card is not null)
            throw new BeeshtihaExeption(409, "Card already exist");

        var mapped = this.mappers.Map<Card>(dto);
        var result = await this.unitOfWork.Cards.InsertAsync(mapped);
        await this.unitOfWork.SaveChangesAsync();

        return this.mappers.Map<CardForResultDto>(result);
    }

    public async ValueTask<IEnumerable<CardForResultDto>> GetAllAsync(PaginationParams @params)
    {
        var cards = await unitOfWork.Cards.SelectAll()
                .ToPagedList(@params)
                .ToListAsync();

        return this.mappers.Map<IEnumerable<CardForResultDto>>(cards);
    }

    public async ValueTask<CardForResultDto> GetByAsync(Expression<Func<Card, bool>> predicate)
    {
        var card = await this.unitOfWork.Cards.SelectAsync(predicate);
        if (card is null)
            throw new BeeshtihaExeption(404, "Card is not Found");

        return this.mappers.Map<CardForResultDto>(card);
    }

    public async ValueTask<bool> RemoveAsync(Expression<Func<Card, bool>> predicate)
    {
        var card = await this.unitOfWork.Cards.SelectAsync(predicate);
        if (card is null)
            throw new BeeshtihaExeption(404, "Card is not Found");

        return true;
    }

    public async ValueTask<CardForResultDto> UpdateAsync(int id, CardForCreationDto dto)
    {
        var card = await this.unitOfWork.Cards.SelectAsync(x => x.Id == id);
        if (card is null)
            throw new BeeshtihaExeption(404, "Couldn't found card");

        var mapped = this.mappers.Map(dto, card);
        await this.unitOfWork.SaveChangesAsync();

        return this.mappers.Map<CardForResultDto>(mapped);
    }
}
