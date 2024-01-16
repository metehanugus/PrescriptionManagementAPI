using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using PrescriptionManagementAPI.Controllers;
using PrescriptionManagementAPI.Models;
using PrescriptionManagementAPI.Services;
using System.Diagnostics;
using System;
using Microsoft.AspNetCore.Authorization;

namespace PrescriptionManagementAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PrescriptionController : ControllerBase
    {
        private readonly PrescriptionService _prescriptionService;

        public PrescriptionController(PrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var prescriptions = await _prescriptionService.GetAllPrescriptionsAsync();
            return Ok(prescriptions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var prescription = await _prescriptionService.GetPrescriptionByIdAsync(id);
            if (prescription == null)
            {
                return NotFound();
            }
            return Ok(prescription);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Prescription prescription)
        {
            await _prescriptionService.AddPrescriptionAsync(prescription);
            return CreatedAtAction(nameof(GetById), new { id = prescription.PrescriptionID }, prescription);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Prescription prescription)
        {
            if (id != prescription.PrescriptionID)
            {
                return BadRequest();
            }

            try
            {
                await _prescriptionService.UpdatePrescriptionAsync(prescription);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PrescriptionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _prescriptionService.DeletePrescriptionAsync(id);
            return NoContent();
        }

        private async Task<bool> PrescriptionExists(int id)
        {
            return await _prescriptionService.GetPrescriptionByIdAsync(id) != null;
        }
    }
}

