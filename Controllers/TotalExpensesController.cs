using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class TotalExpensesController : Controller
    {
        private Montly_ExpensesEntities1 db = new Montly_ExpensesEntities1();

        // GET: TotalExpenses
        public ActionResult Index()
        {
            return View(db.TotalExpenses.ToList());
        }

        // GET: TotalExpenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalExpense totalExpense = db.TotalExpenses.Find(id);
            if (totalExpense == null)
            {
                return HttpNotFound();
            }
            return View(totalExpense);
        }

        // GET: TotalExpenses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TotalExpenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TotalExpense1")] TotalExpense totalExpense)
        {
            if (ModelState.IsValid)
            {
                db.TotalExpenses.Add(totalExpense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(totalExpense);
        }

        // GET: TotalExpenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalExpense totalExpense = db.TotalExpenses.Find(id);
            if (totalExpense == null)
            {
                return HttpNotFound();
            }
            return View(totalExpense);
        }

        // POST: TotalExpenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TotalExpense1")] TotalExpense totalExpense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(totalExpense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(totalExpense);
        }

        // GET: TotalExpenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalExpense totalExpense = db.TotalExpenses.Find(id);
            if (totalExpense == null)
            {
                return HttpNotFound();
            }
            return View(totalExpense);
        }

        // POST: TotalExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TotalExpense totalExpense = db.TotalExpenses.Find(id);
            db.TotalExpenses.Remove(totalExpense);
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
