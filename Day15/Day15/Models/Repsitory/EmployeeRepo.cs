
using Microsoft.EntityFrameworkCore;

namespace Day15.Models.Repsitory
{
    public class EmployeeRepo : IRepository<Employee>
    {

        private readonly CompanyContext _context;

        public EmployeeRepo(CompanyContext context) {

            _context = context;
        }


        public async Task AddAsync(Employee entity)
        {
            await _context.Employees.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Employees
                .Where(e => e.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            await _context.Employees
                .Include(e => e.Department)
                .LoadAsync();
            return _context.Employees.Local.ToList();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            await _context.Employees
                .Include(e => e.Department)
                .LoadAsync();
            return _context.Employees.Local.FirstOrDefault(e => e.Id == id)!;
                   
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
          
        }

        public async Task UpdateAsync(Employee entity)
        {
            await _context.Employees
                .Where(e => e.Id == entity.Id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(e => e.Name, entity.Name)
                    .SetProperty(e => e.Email, entity.Email)
                    .SetProperty(e => e.DepartmentId, entity.DepartmentId));
        }
    }
}
