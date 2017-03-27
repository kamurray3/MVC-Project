using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Murray_P2.Models;

namespace Murray_P2.Controllers
{
    public class JordanCategoriesController : ApiController
    {
        //GET:   /api/Categories/
        [Route("api/Categories")]
        public List<ProductCategory> GetAllJordanCategories()
        {
            JordanDBEntities db = new JordanDBEntities();

            List<ProductCategory> categories = db.ProductCategories
                                                .OrderBy(m => m.CategoryName)
                                                .ToList();

            return categories;
        }

        //GET:   /api/Categories/Shoes
        [Route("api/Categories/{categoryID}")]
        public List<ProductCategory> GetIndividualJordanCategory(string categoryID)
        {
            JordanDBEntities db = new JordanDBEntities();

            List<ProductCategory> categories = new List<ProductCategory>();

            categories = db.ProductCategories
                            .Where(m => m.CategoryName == categoryID)
                            .ToList();

            return categories;
        }
    }
}
