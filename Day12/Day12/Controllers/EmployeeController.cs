using Day12.Models;
using Day12.Models.Repsitory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day12.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IRepository<Employee> _employeeRepo;
        private readonly IRepository<Department> _departmentRepo;

        public EmployeeController(IRepository<Employee> employeeRepo, IRepository<Department> departmentRepo)
        {
            _employeeRepo = employeeRepo;
            _departmentRepo = departmentRepo;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeRepo.GetAllAsync();
            return View(employees);
        }

       

        // GET: EmployeeController/Create
        public  async Task<ActionResult> Create()
        {
            var departments = await _departmentRepo.GetAllAsync();
            ViewBag.DepartmentId = new SelectList(departments, "Id", "Name");
            return View();
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid) {
            await _employeeRepo.AddAsync(employee);
            await _employeeRepo.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
            }
            var departments = await _departmentRepo.GetAllAsync();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View(employee);
        }



        [HttpGet]
        public async Task< IActionResult> Edit(int id)
        {
            var employee = await _employeeRepo.GetByIdAsync(id);
            var departments = await _departmentRepo.GetAllAsync();
            if (employee == null)
            {
                return NotFound();
            }
            ViewBag.DepartmentId = new SelectList(departments, "Id", "Name");
            return View(employee);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if(ModelState.IsValid)
            {
              await _employeeRepo.UpdateAsync(employee);
                await _employeeRepo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var departments = await _departmentRepo.GetAllAsync();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View(employee);
        }



        [HttpGet]
        public async Task< ActionResult> Delete(int id)
        {
            var employee =await _employeeRepo.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

       
        [HttpPost , ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
           await _employeeRepo.DeleteAsync(id);
            await _employeeRepo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task< IActionResult> Details(int id)
        {
            var employee = await _employeeRepo.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
    }
}
