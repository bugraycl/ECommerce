using BusinessLayer.Contacrete;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

namespace ECommerce.Controllers
{
    public class AdminProductController : Controller
    {
        // GET: AdminProduct
        ProductRepository productRepository = new ProductRepository();
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View(productRepository.List());
        }

        public ActionResult Create()
        {
            List<SelectListItem> deger1 = (from i in db.Categories.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.Name,
                                                Value = i.Id.ToString()
                                            }).ToList();
            ViewBag.category = deger1;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product data, HttpPostedFileBase File)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bir hata oluştu!");
            }

            string fileName = Path.GetRandomFileName() + Path.GetExtension(File.FileName);
            string path = Path.Combine("~/Content/Image/" + fileName);
            File.SaveAs(Server.MapPath(path));
            data.Image = fileName;

            productRepository.Insert(data);
            return RedirectToAction("Index");

        }

        public ActionResult Update(int id)
        {
            var update = productRepository.GetById(id);

            List<SelectListItem> deger1 = (from i in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.category = deger1;

            return View (update);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Product data, HttpPostedFileBase File)
        {
            var update = productRepository.GetById(data.Id);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bir hata oluştu!");
            }

            if (File == null)
            {
                update.Name = data.Name;
                update.Description = data.Description;
                update.IsApproved = data.IsApproved;
                update.Popular = data.Popular;
                update.Price = data.Price;
                update.Stock = data.Stock;
                update.CategoryId = data.CategoryId;
                productRepository.Update(update);
                return RedirectToAction("Index");
            }
            else
            {
                update.Name = data.Name;
                update.Description = data.Description;
                update.IsApproved = data.IsApproved;
                update.Popular = data.Popular;
                update.Price = data.Price;
                update.Stock = data.Stock;

                string oldPath = Server.MapPath(@"~/Content/Image/" + update.Image);
                System.IO.File.Delete(oldPath);

                string fileName = Path.GetRandomFileName() + Path.GetExtension(File.FileName);
                string path = Path.Combine("~/Content/Image/" + fileName);
                File.SaveAs(Server.MapPath(path));
                update.Image = fileName;

                update.CategoryId = data.CategoryId;
                productRepository.Update(update);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            var delete = productRepository.GetById(id);
            productRepository.Delete(delete);
            return RedirectToAction("Index");
        }

    }
}