using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Murray_P1.Models;

namespace Murray_P1.Controllers
{
    public class JordanCustomersController : Controller
    {
        // GET: JordanCustomers
        public ActionResult Index()
        {
            return View();
        }

        // GET:  /JordanCustomers/ByState/NC
        public ActionResult ByState(string id)
        {
            JordanDBEntities db = new JordanDBEntities();

            List<ShopCustomer> customers = new List<ShopCustomer>();

            customers = db.ShopCustomers.ToList();

            var sortedList = customers.Where(m => m.CustomerState == id)
                                        .OrderBy(m => m.CustomerFirstName);

            ViewBag.ChosenState = id;

            return View(sortedList);
        }

        //GET:  /JordanCustomers/Details/APetitt@gmail.com
        public ActionResult Details(string id)
        {
            JordanDBEntities db = new JordanDBEntities();

            List<ShopCustomer> customers = new List<ShopCustomer>();

            customers = db.ShopCustomers.ToList();

            var foundCustomer = customers.Where(m => m.CustomerFirstName == id)
                                        .First();

            return View(foundCustomer);
        }
    }
}