using Base.Application.Features.Employees.Commands.CreateEmployee;
using Base.Application.Features.Employees.Queries.GetEmployees;
using Base.Domain.Entities;
using Base.Infrastructure.Persistence;
using Base.WebUI.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Base.WebUI.Controllers
{
    [Authorize]
    public class PersonelsController : BaseController
    {
        private readonly IMediator _mediator;

        public PersonelsController(
            UserManager<ApplicationUser> userManager, 
            ApplicationDbContext context, 
            RoleManager<IdentityRole> roleManager,
            IMediator mediator) 
            : base(userManager, null, context, roleManager)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetEmployeesQuery());
            
            if (!result.IsSuccess)
            {
                // Handle error
                return View(new List<Employee>());
            }

            ViewBag.BreadCrumbFirstItem = "Personel";
            ViewBag.BreadCrumbSecondItem = "Personel Listesi";
            return View(result.Data);
        }

        public IActionResult Create()
        {
            var person = new Employee();
            ViewBag.BreadCrumbFirstItem = "Personel";
            ViewBag.BreadCrumbSecondItem = "Yeni Personel Oluştur";
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            var command = new CreateEmployeeCommand
            {
                Name = employee.Name,
                Email = employee.Email,
                Password = employee.Password,
                PhoneNumber = employee.PhoneNumber
            };

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Error);
                return View(employee);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
