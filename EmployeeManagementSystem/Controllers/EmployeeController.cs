using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Yeh line add karna zaroori hai ToListAsync() ke liye

namespace EmployeeManagementSystem.Controllers
{
    [Authorize]
    public class EmployeeController(AppDbContext _Context) : Controller
    {
        // GET: /Employees
        public async Task<IActionResult> Index()
        {
            // Database se employees ki list async tarike se fetch karein
            var employees = await _Context.Employees.ToListAsync();

            return View(employees);
        }

        // GET: /Employees/Details/

        public async Task<IActionResult> Details(int id)
        {
            var employee = await _Context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
    }

        // GET: /Employees/Create

        public IActionResult Create()
        {
            return View(); 
        }

        // POST: /Employees/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid) return View(employee);

            _Context.Employees.Add(employee);
            await _Context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        // GET: /Employees/Edit/

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _Context.Employees.FindAsync(id);

            if (employee == null) return NotFound();

            return View(employee);
        }

        // POST: /Employees/Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id) return NotFound();

            if (!ModelState.IsValid) return View(employee);

            _Context.Employees.Update(employee);
            await _Context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //GET: /Employees/Delete

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _Context.Employees.FindAsync(id);

            if (employee == null) return NotFound();

            return View(employee);
        }

        // POST: /Employees/Delete

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _Context.Employees.Remove(new Employee { Id = id });
            await _Context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        private bool EmployeeExists(int id) => _Context.Employees.Any(e => e.Id == id);
    }
}