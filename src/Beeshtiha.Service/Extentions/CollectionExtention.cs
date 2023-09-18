using Beeshtiha.Domain.Commons;
using Beeshtiha.Domain.Configurations;
using Beeshtiha.Service.Exeptions;

namespace Beeshtiha.Service.Extentions;

public static class CollectionExtention
{
    public static IQueryable<TEntity> ToPagedList<TEntity>(this IQueryable<TEntity> entities, PaginationParams @params)
           where TEntity : Auditable
    {
        return @params.PageIndex > 0 && @params.PageSize >= 0 ?
            entities.OrderBy(e => e.Id).Skip((@params.PageSize - 1) * @params.PageIndex).Take(@params.PageSize) :
            throw new BeeshtihaExeption(400, "Please, enter valid numbers");
    }
}
