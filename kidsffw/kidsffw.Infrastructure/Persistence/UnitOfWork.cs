using kidsffw.Application.Interfaces.Persistence;
using kidsffw.Infrastructure.Data;

namespace kidsffw.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    protected readonly KidsFfwDbContext _dbContext;
    private IDictionary<Type, dynamic> _repositories;

    public UnitOfWork(KidsFfwDbContext dbContext)
    {
        _dbContext = dbContext;
        _repositories = new Dictionary<Type, dynamic>();
    }

    public IBaseRepositoryAsync<T> Repository<T>()
    {
        var entityType = typeof(T);
        if (_repositories.ContainsKey(entityType))
        {
            return _repositories[entityType];
        }

        var repositoryType = typeof(BaseRepositoryAsync<>);
        var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);

        _repositories.Add(entityType, repository);
        return (IBaseRepositoryAsync<T>)repository;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public async Task RollBackChangesAsync()
    {
        await _dbContext.Database.RollbackTransactionAsync();
    }
}