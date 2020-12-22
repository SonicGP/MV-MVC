using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgendCont.Models;

namespace AgendCont.Controllers
{
    public class EstabelecimentsController : Controller
    {
        private AgentContContext db = new AgentContContext();

        // GET: Estabeleciments
        public ActionResult Index()
        {
            var estabeleciments = db.Estabeleciments.Include(e => e.Profissional);
            return View(estabeleciments.ToList());
        }

        // GET: Estabeleciments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabeleciment estabeleciment = db.Estabeleciments.Find(id);
            if (estabeleciment == null)
            {
                return HttpNotFound();
            }
            return View(estabeleciment);
        }

        // GET: Estabeleciments/Create
        public ActionResult Create()
        {
            ViewBag.ProfissionalId = new SelectList(db.Profissionals, "ProfissionalId", "Nome");
            return View();
        }

        // POST: Estabeleciments/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstabelecimentId,Nome,Endereco,Fone,ProfissionalId")] Estabeleciment estabeleciment)
        {
            if (ModelState.IsValid)
            {
                db.Estabeleciments.Add(estabeleciment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfissionalId = new SelectList(db.Profissionals, "ProfissionalId", "Nome", estabeleciment.ProfissionalId);
            return View(estabeleciment);
        }

        // GET: Estabeleciments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabeleciment estabeleciment = db.Estabeleciments.Find(id);
            if (estabeleciment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfissionalId = new SelectList(db.Profissionals, "ProfissionalId", "Nome", estabeleciment.ProfissionalId);
            return View(estabeleciment);
        }

        // POST: Estabeleciments/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstabelecimentId,Nome,Endereco,Fone,ProfissionalId")] Estabeleciment estabeleciment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estabeleciment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfissionalId = new SelectList(db.Profissionals, "ProfissionalId", "Nome", estabeleciment.ProfissionalId);
            return View(estabeleciment);
        }

        // GET: Estabeleciments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabeleciment estabeleciment = db.Estabeleciments.Find(id);
            if (estabeleciment == null)
            {
                return HttpNotFound();
            }
            return View(estabeleciment);
        }

        // POST: Estabeleciments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estabeleciment estabeleciment = db.Estabeleciments.Find(id);
            db.Estabeleciments.Remove(estabeleciment);
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
