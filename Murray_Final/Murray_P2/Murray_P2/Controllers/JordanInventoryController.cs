using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Murray_P2.Models;

namespace Murray_P2.Controllers
{
    public class JordanInventoryController : ApiController
    {
        List<JordanInventory> products = new List<JordanInventory>();

        //Constructor
        public JordanInventoryController()
        {
            JordanDBEntities db = new JordanDBEntities();

            products = db.JordanInventories
                        .OrderBy(m => m.ProductName)
                        .ToList();
        }

        //GET:   /api/Products/
        [Route("api/Products")]
        public List<JordanInventory> GetAllInventory()
        {
            return products;
        }

        // GET /api/Products/Category/Shoes
        [Route("api/Products/Category/{chosenCategory}")]
        public List<JordanInventory> GetProductsByCategory(string chosenCategory)
        {
            return products.Where(m => m.ProductCategoryCode == chosenCategory)
                            .ToList();
        }

        // GET /api/Products/546480-012
        [Route("api/Products/{chosenProduct}")]
        public JordanInventory GetSingleProduct(string chosenProduct)
        {
            return products.Where(m => m.ProductName == chosenProduct)
                            .First();  //We want the first (and only) object in the collection to return
        }
    }
}
