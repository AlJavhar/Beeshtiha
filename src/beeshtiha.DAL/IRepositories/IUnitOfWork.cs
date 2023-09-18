using Beeshtiha.Domain.Entities;
using System.Net;

namespace beeshtiha.DAL.IRepositories;

public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get; }
    IRepository<Card> Cards { get; }
    IRepository<Dish> Dishes { get; }
    Task<bool> SaveChangesAsync();
}
