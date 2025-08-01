
using Microsoft.EntityFrameworkCore;

namespace Day15.Models.Repsitory
{
    public class DepartmentRepo : IRepository<Department>
    {

        private readonly CompanyContext _context;

        public DepartmentRepo(CompanyContext context) { 
        
            _context = context;
        
        }


        public async Task AddAsync(Department entity)
        {
            await _context.Departments.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Departments
                .Where(d => d.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            await _context.Departments
                .Include(d => d.Employees)
                .LoadAsync();
            return _context.Departments.Local.ToList();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            await _context.Departments
                .Include(d => d.Employees)
                .LoadAsync();
            return _context.Departments.Local.FirstOrDefault(d => d.Id == id)!;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Department entity)
        {
            await _context.Departments
                .Where(d => d.Id == entity.Id)
                .ExecuteUpdateAsync(d => d
                    .SetProperty(d => d.Name, entity.Name));
        }
    }
}
