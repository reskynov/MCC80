using Client.DTOs.Employees;
using Client.Models;
using Client.Contracts;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Client.Controllers;

[Authorize(Roles = "Admin, Manager")]
public class EmployeeController : Controller
{
    private readonly IEmployeeRepository repository;

    public EmployeeController(IEmployeeRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var result = await repository.GetAll();
        var ListEmployee = new List<Employee>();

        if (result.Data != null)
        {
            ListEmployee = result.Data.ToList();
        }
        return View(ListEmployee);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(NewEmployeeDto newEmploye)
    {

        var result = await repository.Post(newEmploye);
        if (result.Status == "200")
        {
            TempData["Success"] = $"Data has been Successfully Added! - {result.Message}!";
            return RedirectToAction(nameof(Index));
        }
        else if (result.Status == "409")
        {
            ModelState.AddModelError(string.Empty, result.Message);
            return View();
        }
        return RedirectToAction(nameof(Index));

    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var result = await repository.Get(id);
        var employee = new EmployeeDto();

        if (result.Data != null)
        {
            employee = (EmployeeDto) result.Data;
        }
        return View(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Update(EmployeeDto emp)
    {
        var result = await repository.Put(emp.Guid, emp);

        if (result.Code == 200)
        {
            TempData["Success"] = $"Data has been Successfully Updated - {result.Message}!";
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(Edit));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await repository.Get(id);
        var employee = new EmployeeDto();

        if (result.Data != null)
        {
            employee = (EmployeeDto)result.Data;
        }
        return View(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(EmployeeDto emp)
    {
        var result = await repository.Delete(emp.Guid);

        if (result.Code == 200)
        {
            TempData["Success"] = $"Data has been Successfully Deleted - {result.Message}!";
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(Delete));
    }
}