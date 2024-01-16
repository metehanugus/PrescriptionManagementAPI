using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrescriptionManagementAPI.Data;
using PrescriptionManagementAPI.Models;

namespace PrescriptionManagementAPI.Services
{
    public class MedicineService
    {
        private readonly PrescriptionManagementContext _context;

        public MedicineService(PrescriptionManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medicine>> SearchMedicinesAsync(string search, int pageNumber, int pageSize)
        {
            var medicines = await _context.Medicines
                                          .Where(m => EF.Functions.Like(m.Name, $"%{search}%"))
                                          .Skip((pageNumber - 1) * pageSize)
                                          .Take(pageSize)
                                          .ToListAsync();
            return medicines;
        }

        public async Task UpdateMedicinePricesAsync(List<Medicine> medicinesWithPrices)
        {
            foreach (var newMedicine in medicinesWithPrices)
            {
                var existingMedicine = await _context.Medicines
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.Name == newMedicine.Name);

                if (existingMedicine != null)
                {
                    existingMedicine.Price = newMedicine.Price;
                    _context.Medicines.Update(existingMedicine);
                }
                else
                {
                    _context.Medicines.Add(newMedicine);
                }
            }

            await _context.SaveChangesAsync();
        }



    }
}
