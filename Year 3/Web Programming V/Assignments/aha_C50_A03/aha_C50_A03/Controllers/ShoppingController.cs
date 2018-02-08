using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace aha_C50_A03.Controllers
{
    public class ShoppingController : Controller
    {
        // GET: ShoppingEntry
        public ActionResult Index()
        {
            checkValid();
            ViewBag.Price = Models.ShoppingList.Instance.CalculatePrice();
            return View(Models.ShoppingList.Instance.GetList());
        }

        // GET: ShoppingEntry/Details/5
        [HttpPost]
        public JsonResult Details(int id)
        {
            Models.ShoppingEntry entry = new Models.ShoppingEntry();
            entry = Models.ShoppingList.Instance.getEntry(id);
            var json = JsonConvert.SerializeObject(entry, new Newtonsoft.Json.Converters.StringEnumConverter());
            return Json(json);
        }

        // GET: ShoppingEntry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingEntry/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Models.ShoppingEntry entry = new Models.ShoppingEntry();
                    entry.productName = collection["productName"];
                    entry.price = collection["price"];
                    entry.quantity = Convert.ToInt16(collection["quantity"]);
                    Models.productCategory category;
                    Enum.TryParse(collection["category"], out category);
                    entry.category = category;
                    Models.ShoppingList.Instance.Create(entry);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShoppingEntry/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Models.ShoppingList.Instance.getEntry(id));
        }

        // POST: ShoppingEntry/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Models.ShoppingEntry entry = new Models.ShoppingEntry();
                    entry.productName = collection["productName"];
                    entry.price = collection["price"];
                    entry.quantity = Convert.ToInt16(collection["quantity"]);
                    Models.productCategory category;
                    Enum.TryParse(collection["category"], out category);
                    entry.category = category;
                    Models.ShoppingList.Instance.updateList(id, entry);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShoppingEntry/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Models.ShoppingList.Instance.getEntry(id));
        }

        // POST: ShoppingEntry/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Models.ShoppingList.Instance.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void checkValid()
        {
            if (Models.ShoppingList.ValidateXML())
            {
                ViewBag.IsValid = false;
            }
            else
            {
                ViewBag.IsValid = true;
            }
        }

        public PartialViewResult GetCreate()
        {

            return PartialView("CreateNewPartial");
        }

        public JsonResult CheckDuplicate(string name)
        {
            bool dupe = Models.ShoppingList.Instance.CheckForDuplicate(name);
            return Json(dupe);
        }

        public JsonResult CheckDuplicateEdit(int id, string name)
        {
            bool dupe = Models.ShoppingList.Instance.CheckForDuplicateEdit(id, name);
            return Json(dupe);
        }



    }
}
