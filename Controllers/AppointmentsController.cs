using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_project.Data;
using MVC_project.Models;

namespace MVC_project.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly clinicdatabaseDbContext _context;

        public AppointmentsController(clinicdatabaseDbContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var clinicdatabaseDbContext = _context.Appointment.Include(a => a.Clinic).Include(a => a.Docter).Include(a => a.Patient);
            return View(await clinicdatabaseDbContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Clinic)
                .Include(a => a.Docter)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["ClinicId"] = new SelectList(_context.clinic, "Id", "Clinic_address");
            ViewData["DocterID"] = new SelectList(_context.docter, "Id", "Email");
            ViewData["PatientID"] = new SelectList(_context.patient, "Id", "Name");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClinicId,DocterID,PatientID,Appointment_date_time")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClinicId"] = new SelectList(_context.clinic, "Id", "Clinic_address", appointment.ClinicId);
            ViewData["DocterID"] = new SelectList(_context.docter, "Id", "Email", appointment.DocterID);
            ViewData["PatientID"] = new SelectList(_context.patient, "Id", "Name", appointment.PatientID);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["ClinicId"] = new SelectList(_context.clinic, "Id", "Clinic_address", appointment.ClinicId);
            ViewData["DocterID"] = new SelectList(_context.docter, "Id", "Email", appointment.DocterID);
            ViewData["PatientID"] = new SelectList(_context.patient, "Id", "Name", appointment.PatientID);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClinicId,DocterID,PatientID,Appointment_date_time")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClinicId"] = new SelectList(_context.clinic, "Id", "Clinic_address", appointment.ClinicId);
            ViewData["DocterID"] = new SelectList(_context.docter, "Id", "Email", appointment.DocterID);
            ViewData["PatientID"] = new SelectList(_context.patient, "Id", "Name", appointment.PatientID);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Clinic)
                .Include(a => a.Docter)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.Id == id);
        }
    }
}
