using PetzeyPetDataAccessLayer;
using PetzeyPetDTOs;
using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace PetzeyPetApi.Controllers
{
    public class PetController : ApiController
    {
        IPetDbRepository repo = new PetDbRepository();
        // GET: Pet
      public IHttpActionResult GetPets()
        {
            List<PetDto> pets=  repo.GetAllPets();
            return Ok(pets);
        }

        public IHttpActionResult GetPetById(int id)
        {
            Pet pet = repo.GetPetById(id);
            return Ok(pet);
        }
    }
}