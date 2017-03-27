using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Murray_P1.Models;

namespace Murray_P1.Controllers
{
    public class JordanStatesController : Controller
    {
        //Declare a class-level List Collection of JordanStates objects
        List<PossibleState> states = new List<PossibleState>();

        //Class Constructor method
        public JordanStatesController()
        {
            JordanDBEntities db = new JordanDBEntities();

            states = db.PossibleStates.ToList();
        }

        // GET: JordanStates
        public ActionResult Index()
        {

            return View();
        }

        // GET: JordanStates/ChooseState
        public ActionResult ChooseState()
        {
            //JordanDBEntities db = new JordanDBEntities();

            //List<PossibleState> customers = new List<PossibleState>();

            //customers = db.PossibleStates.ToList();

            var sortedList = states
                                .OrderBy(m => m.FullStateName)
                                .ToList();

            return View(sortedList);
        }
    }
}
