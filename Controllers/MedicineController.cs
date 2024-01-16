using Microsoft.AspNetCore.Mvc;
using PrescriptionManagementAPI.Data;

[ApiController]
[Route("[controller]")]
public class MedicineController : ControllerBase
{
    private readonly PrescriptionManagementContext _context;

    public MedicineController(PrescriptionManagementContext context)
    {
        _context = context;
    }

    [HttpGet("search")]
    public IActionResult SearchMedicine(string query)
    {
        var medicines = _context.Medicines
            .Where(m => m.Name.Contains(query))
            .Select(m => m.Name)
            .ToList();

        return Ok(new { medicationNames = medicines });
    }
}
