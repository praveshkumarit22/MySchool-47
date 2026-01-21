using Microsoft.EntityFrameworkCore;
using SchoolERP.Domain.Interfaces;
using SchoolERP.Infrastructure.Data;

namespace SchoolERP.Infrastructure.Repositories;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly SchoolDbContext _db;

    public GenericRepository(SchoolDbContext db)
    {
        _db = db;
    }

    public async Task<T?> GetByIdAsync(string  id)
        => await _db.Set<T>().FindAsync(id);

    public async Task<List<T>> GetAllAsync()
        => await _db.Set<T>().ToListAsync();

    public async Task AddAsync(T entity)
        => await _db.Set<T>().AddAsync(entity);

    public void Update(T entity)
        => _db.Set<T>().Update(entity);

    public void Remove(T entity)
        => _db.Set<T>().Remove(entity);
}
