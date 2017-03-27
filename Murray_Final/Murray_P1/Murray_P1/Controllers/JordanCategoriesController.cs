using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Murray_P1.Models;

namespace Murray_P1.Controllers
{
    public class JordanCategoriesController : Controller
    {
        //Declare a class-level List Collection of JordanCategory objects
        List<ProductCategory> categories = new List<ProductCategory>();

        //Class Constructor method
        public JordanCategoriesController()
        {
            JordanDBEntities db = new JordanDBEntities();

            categories = db.ProductCategories.ToList();
        }

        // GET: JordanCategories
        public ActionResult Index()
        {

            return View();
        }

        // GET: JordanCategories/ChooseCategory
        public ActionResult ChooseCategory()
        {
            //JordanDBEntities db = new JordanDBEntities();

            //List<ProductCategory> categories = new List<ProductCategory>();

            //categories = db.ProductCategories.ToList();

            var sortedList = categories
                                .OrderBy(m => m.CategoryName)
                                .ToList();

            return View(sortedList);
        }
    }
}