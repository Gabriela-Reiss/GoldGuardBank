using BankSystem.Domain.Repositories.Interfaces;
using BankSystem.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infraestructure.Repositories.Implementations;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly BankSystemDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(BankSystemDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        _dbSet.Add(entity);
    }

  

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return _dbSet.ToList();
    }

    

    public async Task<T?> GetByIdAsync(int id)
    {
        return _dbSet.Find(id);
    }

    

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}
