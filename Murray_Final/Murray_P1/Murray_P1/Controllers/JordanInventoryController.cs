using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Murray_P1.Models;

namespace Murray_P1.Controllers
{
    public class JordanInventoryController : Controller
    {
        // GET: JordanInventory
        public ActionResult Index()
        {
            return View();
        }

        // GET:  /JordanInventory/ByCategory/Shoes
        public ActionResult ByCategory(string id)
        {
            JordanDBEntities db = new JordanDBEntities();

            List<JordanInventory> inventory = new List<JordanInventory>();

            inventory = db.JordanInventories.ToList();

            var sortedList = inventory.Where(m => m.ProductCategoryCode == id)
                                        .OrderBy(m => m.ProductName);

            ViewBag.ChosenCategoryCode = id;

            return View(sortedList);
        }

        //GET:  /JordanInventory/Details/546480-012
        public ActionResult Details(string id)
        {
            JordanDBEntities db = new JordanDBEntities();

            List<JordanInventory> inventory = new List<JordanInventory>();

            inventory = db.JordanInventories.ToList();

            var foundProduct = inventory.Where(m => m.ItemStyleNum == id)
                                        .First();

            return View(foundProduct);
        }
    }
}