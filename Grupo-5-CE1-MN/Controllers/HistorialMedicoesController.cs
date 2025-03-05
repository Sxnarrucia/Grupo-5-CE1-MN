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
    public class HistorialMedicoesController : Controller
    {
        private CE01Context db = new CE01Context();

        // GET: HistorialMedicoes
        public ActionResult Index()
        {
            var historialMedico = db.HistorialMedico.Include(h => h.Doctor).Include(h => h.Paciente);
            return View(historialMedico.ToList());
        }

        // GET: HistorialMedicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialMedico historialMedico = db.HistorialMedico.Find(id);
            if (historialMedico == null)
            {
                return HttpNotFound();
            }
            return View(historialMedico);
        }

        // GET: HistorialMedicoes/Create
        public ActionResult Create()
        {
            ViewBag.DoctorID = new SelectList(db.Doctor, "Id", "Nombre");
            ViewBag.PacienteID = new SelectList(db.Paciente, "Id", "Nombre");
            return View();
        }

        // POST: HistorialMedicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PacienteID,DoctorID,Diagnostico,Tratamiento,FechaRegistro,RecetaMedica")] HistorialMedico historialMedico)
        {
            if (!historialMedico.DiagnosticoValido())
            {
                ModelState.AddModelError("Diagnostico", "El diagnóstico debe tener más de 10 caracteres.");
            }

            if (ModelState.IsValid)
            {
                db.HistorialMedico.Add(historialMedico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorID = new SelectList(db.Doctor, "Id", "Nombre", historialMedico.DoctorID);
            ViewBag.PacienteID = new SelectList(db.Paciente, "Id", "Nombre", historialMedico.PacienteID);
            return View(historialMedico);
        }


        // GET: HistorialMedicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialMedico historialMedico = db.HistorialMedico.Find(id);
            if (historialMedico == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorID = new SelectList(db.Doctor, "Id", "Nombre", historialMedico.DoctorID);
            ViewBag.PacienteID = new SelectList(db.Paciente, "Id", "Nombre", historialMedico.PacienteID);
            return View(historialMedico);
        }

        // POST: HistorialMedicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PacienteID,DoctorID,Diagnostico,Tratamiento,FechaRegistro,RecetaMedica")] HistorialMedico historialMedico)
        {
            if (!historialMedico.DiagnosticoValido())
            {
                ModelState.AddModelError("Diagnostico", "El diagnóstico debe tener más de 10 caracteres.");
            }

            if (ModelState.IsValid)
            {
                db.Entry(historialMedico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorID = new SelectList(db.Doctor, "Id", "Nombre", historialMedico.DoctorID);
            ViewBag.PacienteID = new SelectList(db.Paciente, "Id", "Nombre", historialMedico.PacienteID);
            return View(historialMedico);
        }


        // GET: HistorialMedicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialMedico historialMedico = db.HistorialMedico.Find(id);
            if (historialMedico == null)
            {
                return HttpNotFound();
            }
            return View(historialMedico);
        }

        // POST: HistorialMedicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistorialMedico historialMedico = db.HistorialMedico.Find(id);
            db.HistorialMedico.Remove(historialMedico);
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

