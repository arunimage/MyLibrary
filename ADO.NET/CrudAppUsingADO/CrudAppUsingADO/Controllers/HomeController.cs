using Microsoft.AspNetCore.Mvc;
using BLL.Implementation;
using Common.Models;
using CrudAppUsingADO.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace CrudAppUsingADO.Controllers
{
    public class HomeController : Controller
    {

        // routing in mvc
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllEmployeesList()
        {
            var emplistViewModel = new List<EmployeeViewModel>();

            var employees = new EmployeeBLL();
            List<EmployeeInfo> data = employees.GetEmployeesBLL();

            foreach (EmployeeInfo emp in data)
            {
                var employee = new EmployeeViewModel();
                employee.Id = emp.Id;
                employee.name = emp.name;
                employee.gender = emp.gender;
                employee.age = emp.age;
                employee.city = emp.city;
                employee.salary = emp.salary;
                emplistViewModel.Add(employee);
            }

            //var viewModel = data.Select(emp => new EmployeeViewModel
            //{
            //    Id = emp.Id,
            //    name = emp.name,
            //    gender = emp.gender,
            //    age = emp.age,
            //    city = emp.city,
            //    salary = emp.salary,
            //}).ToList();

            return View(emplistViewModel);
        }

        [HttpGet]
        public IActionResult AddEmployee(EmployeeViewModel? employeeViewModel)
        {
            return View(employeeViewModel);
        }

        [HttpPost]
        public IActionResult SaveEmployee(EmployeeViewModel viewModel) //return type, filters
        {
            EmployeeInfo employeeInfo = new EmployeeInfo();
            // how to ingore property in modelstate
            if (ModelState.IsValid)
            {
                employeeInfo.Id = viewModel.Id;
                employeeInfo.name = viewModel.name;
                employeeInfo.gender = viewModel.gender;
                employeeInfo.age = viewModel.age;
                employeeInfo.salary = viewModel.salary;
                employeeInfo.city = viewModel.city;
            }

            EmployeeBLL employee = new EmployeeBLL(); //BLL
            employee.SaveEmployee(employeeInfo);
            return RedirectToAction("GetAllEmployeesList");
            //return View();
        }

        [HttpGet]
        public IActionResult DeleteEmployee(int id)
        {
            EmployeeBLL employeeBLL = new EmployeeBLL();
            employeeBLL.DeleteEmployeeBLL(id);
            return RedirectToAction("GetAllEmployeesList");
        }

        public IActionResult GetEmployeeById(int id)
        {
            EmployeeBLL employeeBLL = new EmployeeBLL();
            var employee = employeeBLL.GetEmployeeByIdBLL(id);
            var empViewModel= new EmployeeViewModel();
            if (employee != null)
            {
                empViewModel.Id = id;
                empViewModel.name = employee.name;
                empViewModel.gender = employee.gender;
                empViewModel.age = employee.age;
                empViewModel.salary = employee.salary;
                empViewModel.city = employee.city;
            }
            //viewModel VS info
            //return RedirectToPage("AddEmployee", empViewModel);
            return RedirectToAction("AddEmployee", "Home", empViewModel);
        }

        public IActionResult EditEmployee(int id)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            EmployeeBLL EmployeeBLL = new EmployeeBLL();
            EmployeeBLL.EditEmployeeBLL(id);
            return RedirectToAction("GetAllEmployeesList");
        }
    }
}
