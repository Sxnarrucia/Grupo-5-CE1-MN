using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Grupo_5_CE1_MN.Models;

namespace Grupo_5_CE1_MN.Controllers
{
    public class CitaMedicasController : Controller
    {
        private CE01Context db = new CE01Context();

        // GET: CitaMedicas
        public ActionResult Index()
        {
            var citaMedica = db.CitaMedica.Include(c => c.Doctor).Include(c => c.Paciente);
            return View(citaMedica.ToList());
        }

        // GET: CitaMedicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CitaMedica citaMedica = db.CitaMedica.Find(id);
            if (citaMedica == null)
            {
                return HttpNotFound();
            }
            return View(citaMedica);
        }

        // GET: CitaMedicas/Create
        public ActionResult Create()
        {
            ViewBag.DoctorID = new SelectList(db.Doctor, "Id", "Nombre");
            ViewBag.PacienteID = new SelectList(db.Paciente, "Id", "Nombre");
            return View();
        }

        // POST: CitaMedicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCita,PacienteID,DoctorID,FechaCita,HoraCita,EstadoCita,MotivoCita,NotasDoctor")] CitaMedica citaMedica)
        {
            if (ModelState.IsValid)
            {
                bool horarioOcupado = db.CitaMedica.Any(c =>
                    c.DoctorID == citaMedica.DoctorID &&
                    c.FechaCita == citaMedica.FechaCita &&
                    c.HoraCita == citaMedica.HoraCita);

                if (horarioOcupado)
                {
                    ModelState.AddModelError("", "El doctor ya tiene una cita en este horario.");
                }
                else
                {
                    db.CitaMedica.Add(citaMedica);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.DoctorID = new SelectList(db.Doctor, "Id", "Nombre", citaMedica.DoctorID);
            ViewBag.PacienteID = new SelectList(db.Paciente, "Id", "Nombre", citaMedica.PacienteID);
            return View(citaMedica);
        }


        // POST: CitaMedicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCita,PacienteID,DoctorID,FechaCita,HoraCita,EstadoCita,MotivoCita,NotasDoctor")] CitaMedica citaMedica)
        {
            if (ModelState.IsValid)
            {
                bool horarioOcupado = db.CitaMedica.Any(c =>
                    c.DoctorID == citaMedica.DoctorID &&
                    c.FechaCita == citaMedica.FechaCita &&
                    c.HoraCita == citaMedica.HoraCita &&
                    c.IdCita != citaMedica.IdCita);

                if (horarioOcupado)
                {
                    ModelState.AddModelError("", "El doctor ya tiene una cita en este horario.");
                }
                else
                {
                    db.Entry(citaMedica).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.DoctorID = new SelectList(db.Doctor, "Id", "Nombre", citaMedica.DoctorID);
            ViewBag.PacienteID = new SelectList(db.Paciente, "Id", "Nombre", citaMedica.PacienteID);
            return View(citaMedica);
        }


        // GET: CitaMedicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CitaMedica citaMedica = db.CitaMedica.Find(id);
            if (citaMedica == null)
            {
                return HttpNotFound();
            }
            return View(citaMedica);
        }

        // POST: CitaMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CitaMedica citaMedica = db.CitaMedica.Find(id);
            db.CitaMedica.Remove(citaMedica);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
