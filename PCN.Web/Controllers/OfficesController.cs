
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PCN.Web.Models;

namespace PCN.Web.Controllers
{
    public class OfficesController : Controller
    {
        private Context db = new Context();

        // GET: Offices
        public async Task<ActionResult> Index()
        {
            return View(await db.Offices.ToListAsync());
        }

        // GET: Offices/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office office = await db.Offices.FindAsync(id);
            if (office == null)
            {
                return HttpNotFound();
            }
            return View(office);
        }

        // GET: Offices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Offices/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Office office)
        {
            if (ModelState.IsValid)
            {
                db.Offices.Add(office);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(office);
        }

        // GET: Offices/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office office = await db.Offices.FindAsync(id);
            if (office == null)
            {
                return HttpNotFound();
            }
            return View(office);
        }

        // POST: Offices/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Office office)
        {
            if (ModelState.IsValid)
            {
                db.Entry(office).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(office);
        }

        // GET: Offices/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office office = await db.Offices.FindAsync(id);
            if (office == null)
            {
                return HttpNotFound();
            }
            return View(office);
        }

        // POST: Offices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Office office = await db.Offices.FindAsync(id);
            db.Offices.Remove(office);
            await db.SaveChangesAsync();
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
