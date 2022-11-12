using log4net;
using Newtonsoft.Json;
using PetzeyPetBusinessLayer;
using PetzeyPetDTOs;
using PetzeyPetEntities;
using PetzeyPetExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;

namespace PetzeyPetApi.Controllers
{
    public class AllergyController : ApiController
    {
        IAllergyBll allergyBll;
        ILog log;

        public AllergyController(IAllergyBll allergyBll)
        {
            this.allergyBll = allergyBll;
            this.log = log4net.LogManager.GetLogger(typeof(AllergyController));
        }


        [Route("api/Allergy/AddAllergy")]
        public async Task<IHttpActionResult> AddAllergy(Allergy allergy)
        {
            try
            {
                log.Debug("Inside AddAllergy of AllergyController");
                log.Debug($"Recieved Data is {JsonConvert.SerializeObject(allergy)} allergy");
                return Ok(await allergyBll.AddAllergy(allergy));



            }
            catch (AllergyAlreadyExistsException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }
        }
        [System.Web.Http.HttpGet]
        [EnableQuery]
        public IQueryable<Allergy> GetAllPets()
        {
            return allergyBll.GetAllAllergies().AsQueryable();
        }
    }
}
