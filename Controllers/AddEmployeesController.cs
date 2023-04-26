using Employee.Data;
using Employee.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    public class AddEmployeesController : Controller
    {
        private readonly EmployeeDbContext employeesDbContext;
        public AddEmployeesController(EmployeeDbContext employeesDbContext)
        {
            this.employeesDbContext = employeesDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var employee = employeesDbContext.Employees.ToList();
            return View(employee);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //добавление сотрудника
        [HttpPost]
        public IActionResult Add(Employees employee)
        {
            if (ModelState.IsValid)
            {
                employeesDbContext.Employees.Add(employee);
                employeesDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = employeesDbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        //метод для редактирования
        [HttpPost]
        public IActionResult Edit(Employees employee)
        {
            if (ModelState.IsValid)
            {
                employeesDbContext.Employees.Update(employee);
                employeesDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        //метод для удаления
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var employee = employeesDbContext.Employees.Find(id);
            if (employee != null)
            {
                employeesDbContext.Employees.Remove(employee);
                employeesDbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
