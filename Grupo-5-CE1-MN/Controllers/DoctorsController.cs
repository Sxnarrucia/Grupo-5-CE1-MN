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
    public class DoctorsController : Controller
    {
        private CE01Context db = new CE01Context();

        // GET: Doctors
        public ActionResult Index()
        {
            return View(db.Doctor.ToList());
        }

        // GET: Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctor.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellidos,NumeroLicenciaMedica,Telefono,Correo,Especialidad,HoraInicioJornada,HoraFinJornada")] Doctor doctor)
        {
            if (doctor.HoraInicioJornada >= doctor.HoraFinJornada)
            {
                ModelState.AddModelError("", "La hora de inicio debe ser menor que la hora de fin.");
            }

            // Validar si el horario ya está ocupado por otro doctor
            bool horarioOcupado = db.Doctor.Any(d =>
                d.HoraInicioJornada < doctor.HoraFinJornada &&
                d.HoraFinJornada > doctor.HoraInicioJornada);

            if (horarioOcupado)
            {
                ModelState.AddModelError("", "Otro doctor ya tiene un horario que se superpone con este.");
            }

            if (ModelState.IsValid)
            {
                db.Doctor.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctor);
        }



        // GET: Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctor.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellidos,NumeroLicenciaMedica,Telefono,Correo,Especialidad,HoraInicioJornada,HoraFinJornada")] Doctor doctor)
        {
            if (doctor.HoraInicioJornada >= doctor.HoraFinJornada)
            {
                ModelState.AddModelError("", "La hora de inicio debe ser menor que la hora de fin.");
            }

            // Validar si otro doctor ya tiene el mismo horario
            bool horarioOcupado = db.Doctor.Any(d =>
                d.Id != doctor.Id && // Excluir el doctor actual para evitar conflicto consigo mismo
                d.HoraInicioJornada < doctor.HoraFinJornada &&
                d.HoraFinJornada > doctor.HoraInicioJornada);

            if (horarioOcupado)
            {
                ModelState.AddModelError("", "Otro doctor ya tiene un horario que se superpone con este.");
            }

            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctor);
        }



        // GET: Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctor.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctor.Find(id);
            db.Doctor.Remove(doctor);
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
