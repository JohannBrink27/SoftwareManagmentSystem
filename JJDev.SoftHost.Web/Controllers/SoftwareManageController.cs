using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JJDev.SoftHost.Web.Models;
using System.Web.Hosting;

namespace JJDev.SoftHost.Web.Controllers
{
    [Authorize]
    public class SoftwareManageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SoftwareManage
        public async Task<ActionResult> Index()
        {
            return View(await db.SoftwareViewModels.ToListAsync());
        }

        public FileResult Download(string dp)
        {
            // This must point a file on the server.
            // This file's content will be packaged and presented to the user for download.      
            string pathToServerFile = HostingEnvironment.MapPath($"~/Downloads/{dp}");

            // File content is read into a binary format.
            byte[] fileBytes = System.IO.File.ReadAllBytes(pathToServerFile);

            // Name the file will be saved as on the user's pc.
            string fileName = System.IO.Path.GetFileName(dp);

            // A special object is created that contains all relevant information required for a download.
            FileContentResult fileContentResult = File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

            // Give the above mentioned object back to the "front end (browser)".
            return fileContentResult;
        }

        // GET: SoftwareManage/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoftwareViewModels softwareViewModels = await db.SoftwareViewModels.FindAsync(id);
            if (softwareViewModels == null)
            {
                return HttpNotFound();
            }
            return View(softwareViewModels);
        }

        // GET: SoftwareManage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SoftwareManage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,LicenseKey,Name,DownloadPath")] SoftwareViewModels softwareViewModels)
        {
            if (ModelState.IsValid)
            {
                db.SoftwareViewModels.Add(softwareViewModels);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(softwareViewModels);
        }

        // GET: SoftwareManage/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoftwareViewModels softwareViewModels = await db.SoftwareViewModels.FindAsync(id);
            if (softwareViewModels == null)
            {
                return HttpNotFound();
            }
            return View(softwareViewModels);
        }

        // POST: SoftwareManage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,LicenseKey,Name,DownloadPath")] SoftwareViewModels softwareViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(softwareViewModels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(softwareViewModels);
        }

        // GET: SoftwareManage/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoftwareViewModels softwareViewModels = await db.SoftwareViewModels.FindAsync(id);
            if (softwareViewModels == null)
            {
                return HttpNotFound();
            }
            return View(softwareViewModels);
        }

        // POST: SoftwareManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SoftwareViewModels softwareViewModels = await db.SoftwareViewModels.FindAsync(id);
            db.SoftwareViewModels.Remove(softwareViewModels);
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
