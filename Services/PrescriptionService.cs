using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrescriptionManagementAPI.Data;
using PrescriptionManagementAPI.Models;

namespace PrescriptionManagementAPI.Services
{
    public class PrescriptionService
    {
        private readonly PrescriptionManagementContext _context;

        public PrescriptionService(PrescriptionManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync()
        {
            return await _context.Prescriptions
                                 .Include(p => p.PrescriptionDetails)
                                 .ToListAsync();
        }

        public async Task<Prescription> GetPrescriptionByIdAsync(int id)
        {
            return await _context.Prescriptions
                                 .Include(p => p.PrescriptionDetails)
                                 .FirstOrDefaultAsync(p => p.PrescriptionID == id);
        }

        public async Task AddPrescriptionAsync(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePrescriptionAsync(Prescription prescription)
        {
            _context.Entry(prescription).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePrescriptionAsync(int id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription != null)
            {
                _context.Prescriptions.Remove(prescription);
                await _context.SaveChangesAsync();
            }
        }
    }
}
