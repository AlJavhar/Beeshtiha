using AutoMapper;
using beeshtiha.DAL.IRepositories;
using Beeshtiha.Domain.Configurations;
using Beeshtiha.Domain.Entities;
using Beeshtiha.Service.DTOs.Card;
using Beeshtiha.Service.DTOs.User;
using Beeshtiha.Service.Exeptions;
using Beeshtiha.Service.Extentions;
using Beeshtiha.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Beeshtiha.Service.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mappers;

    public UserService(IUnitOfWork unitOfWork, IMapper mappers)
    {
        this.unitOfWork = unitOfWork;
        this.mappers = mappers;
    }

    public async ValueTask<UserForResultDto> AddCardAsync(UserForCreationDto dto)
    {
        var user = await this.unitOfWork.Users.SelectAsync(x => x.Phone == dto.Phone);
        if (user is not null)
            throw new BeeshtihaExeption(409, "User already exist");

        var mapped = this.mappers.Map<User>(dto);
        var result = await this.unitOfWork.Users.InsertAsync(mapped);
        await this.unitOfWork.SaveChangesAsync();

        return this.mappers.Map<UserForResultDto>(result);
    }

    public async ValueTask<IEnumerable<UserForResultDto>> GetAllAsync(PaginationParams @params)
    {
        var users = await unitOfWork.Users.SelectAll()
                .ToPagedList(@params)
                .ToListAsync();

        return this.mappers.Map<IEnumerable<UserForResultDto>>(users);
    }

    public async ValueTask<UserForResultDto> GetByAsync(Expression<Func<User, bool>> predicate)
    {
        var user = await this.unitOfWork.Users.SelectAsync(predicate);
        if (user is null)
            throw new BeeshtihaExeption(404, "User is not Found");

        return this.mappers.Map<UserForResultDto>(user);
    }

    public async ValueTask<bool> RemoveAsync(Expression<Func<User, bool>> predicate)
    {
        var user = await this.unitOfWork.Users.SelectAsync(predicate);
        if (user is null)
            throw new BeeshtihaExeption(404, "User is not Found");

        return true;
    }

    public async ValueTask<UserForResultDto> UpdateAsync(int id, UserForCreationDto dto)
    {
        var user = await this.unitOfWork.Users.SelectAsync(x => x.Id == id);
        if (user is null)
            throw new BeeshtihaExeption(404, "Couldn't found user");

        var mapped = this.mappers.Map(dto, user);
        await this.unitOfWork.SaveChangesAsync();

        return this.mappers.Map<UserForResultDto>(mapped);
    }
}
