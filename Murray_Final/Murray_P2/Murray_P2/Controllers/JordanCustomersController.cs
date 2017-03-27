using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Murray_P2.Models;

namespace Murray_P2.Controllers
{
    public class JordanCustomersController : ApiController
    {
        List<ShopCustomer> customers = new List<ShopCustomer>();

        //Constructor
        public JordanCustomersController()
        {
            JordanDBEntities db = new JordanDBEntities();

            customers = db.ShopCustomers
                        .OrderBy(m => m.CustomerFirstName)
                        .ToList();
        }

        //GET:   /api/Customers/
        [Route("api/Customers")]
        public List<ShopCustomer> GetAllCustomers()
        {
            return customers;
        }

        // GET /api/Customers/State/NC
        [Route("api/Customers/State/{chosenState}")]
        public List<ShopCustomer> GetCustomersByState(string chosenState)
        {
            return customers.Where(m => m.CustomerState == chosenState)
                            .ToList();
        }

        // GET /api/Customers/APetitt@gmail.com
        [Route("api/Customers/{chosenCustomer}")]
        public ShopCustomer GetSingleCustomer(string chosenCustomer)
        {
            return customers.Where(m => m.CustomerFirstName == chosenCustomer)
                            .First();  //We want the first (and only) object in the collection to return
        }
    }
}
