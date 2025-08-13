using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class EmployeeController : Controller
{
    private readonly AppDbContext _context;
    public EmployeeController(AppDbContext context) { _context = context; }

    [HttpGet]
    public IActionResult Index() => View(_context.Employees.ToList());

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        if (ModelState.IsValid)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(employee);
    }

    // Add Edit, Delete actions similarly
}
