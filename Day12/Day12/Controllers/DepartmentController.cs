using Day12.Models.Repsitory;
using Day12.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day12.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IRepository<Department> _departmentRepo;

        public DepartmentController(IRepository<Department> departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepo.GetAllAsync();
            return View(departments);
        }

        
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                await _departmentRepo.AddAsync(department);
                await _departmentRepo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }


        [HttpGet]
        public async Task< IActionResult> Edit(int id)
        {
            var department = await _departmentRepo.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }


        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult >Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                await _departmentRepo.UpdateAsync(department);
                await _departmentRepo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }



        [HttpGet]
        public async Task< IActionResult> Delete(int id)
        {
            var department = await _departmentRepo.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {

                await  _departmentRepo.DeleteAsync(id);
                await _departmentRepo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
        }


        [HttpGet]
        public async Task< IActionResult> Details(int id)
        {
            var department = await _departmentRepo.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        

      

     

       
    }
}
