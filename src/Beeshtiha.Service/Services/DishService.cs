using AutoMapper;
using beeshtiha.DAL.IRepositories;
using Beeshtiha.Domain.Configurations;
using Beeshtiha.Domain.Entities;
using Beeshtiha.Service.DTOs.Card;
using Beeshtiha.Service.DTOs.Dish;
using Beeshtiha.Service.Exeptions;
using Beeshtiha.Service.Extentions;
using Beeshtiha.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Beeshtiha.Service.Services;

public class DishService : IDishService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mappers;

    public DishService(IUnitOfWork unitOfWork, IMapper mappers)
    {
        this.unitOfWork = unitOfWork;
        this.mappers = mappers;
    }

    public async ValueTask<DishForResultDto> AddCardAsync(DishForCreationDto dto)
    {
        var dish = await this.unitOfWork.Dishes.SelectAsync(x => x.Name == dto.Name);
        if (dish is not null)
            throw new BeeshtihaExeption(409, "Dish already exist");

        var mapped = this.mappers.Map<Dish>(dto);
        var result = await this.unitOfWork.Dishes.InsertAsync(mapped);
        await this.unitOfWork.SaveChangesAsync();

        return this.mappers.Map<DishForResultDto>(result);
    }

    public async ValueTask<IEnumerable<DishForResultDto>> GetAllAsync(PaginationParams @params)
    {
        var dishes = await unitOfWork.Dishes.SelectAll()
               .ToPagedList(@params)
               .ToListAsync();

        return this.mappers.Map<IEnumerable<DishForResultDto>>(dishes);
    }

    public async ValueTask<DishForResultDto> GetByAsync(Expression<Func<Dish, bool>> predicate)
    {
        var dish = await this.unitOfWork.Dishes.SelectAsync(predicate);
        if (dish is null)
            throw new BeeshtihaExeption(404, "Dish is not Found");

        return this.mappers.Map<DishForResultDto>(dish);
    }

    public async ValueTask<bool> RemoveAsync(Expression<Func<Dish, bool>> predicate)
    {
        var dish = await this.unitOfWork.Dishes.SelectAsync(predicate);
        if (dish is null)
            throw new BeeshtihaExeption(404, "Dish is not Found");

        return true;
    }

    public async ValueTask<DishForResultDto> UpdateAsync(int id, DishForCreationDto dto)
    {
        var dish = await this.unitOfWork.Dishes.SelectAsync(x => x.Id == id);
        if (dish is null)
            throw new BeeshtihaExeption(404, "Couldn't found dish");

        var mapped = this.mappers.Map(dto, dish);
        await this.unitOfWork.SaveChangesAsync();

        return this.mappers.Map<DishForResultDto>(mapped);
    }
}
