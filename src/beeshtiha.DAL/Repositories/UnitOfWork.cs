using beeshtiha.DAL.DbContexts;
using beeshtiha.DAL.IRepositories;
using beeshtiha.DAL.Repository;
using Beeshtiha.Domain.Entities;

namespace beeshtiha.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly BeeshtihaDbContext dbContext;

    public UnitOfWork(BeeshtihaDbContext dbContext)
    {
        this.dbContext = dbContext;

        Users = new Repository<User>(dbContext);
        Dishes = new Repository<Dish>(dbContext);
        Cards = new Repository<Card>(dbContext);

    }

    public IRepository<User> Users { get; private set; }
    public IRepository<Card> Cards { get; private set; }
    public IRepository<Dish> Dishes { get; private set; }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await dbContext.SaveChangesAsync() > 0;
    }

}
