using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Murray_P2.Models;

namespace Murray_P2.Controllers
{
    public class JordanStatesController : ApiController
    {
        //GET:   /api/States/
        [Route("api/States")]
        public List<PossibleState> GetAllJordanStates()
        {
            JordanDBEntities db = new JordanDBEntities();

            List<PossibleState> states = db.PossibleStates
                                                .OrderBy(m => m.FullStateName)
                                                .ToList();

            return states;
        }

        //GET:   /api/States/NC
        [Route("api/States/{stateID}")]
        public List<PossibleState> GetIndividualJordanState(string stateID)
        {
            JordanDBEntities db = new JordanDBEntities();

            List<PossibleState> states = new List<PossibleState>();

            states = db.PossibleStates
                            .Where(m => m.StateAbbr == stateID)
                            .ToList();

            return states;
        }
    }
}
