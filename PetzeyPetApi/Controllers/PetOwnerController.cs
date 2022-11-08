using PetzeyPetDataAccessLayer.PetOwnerRepository;
using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetzeyPetApi.Controllers
{
    public class PetOwnerController : ApiController
    {
        private IPetOwnerRepository repo=new PetOwnerRepository();
        public IHttpActionResult Post(long OwnerID, string picUrl)
        {
            // validation
            if (!ModelState.IsValid)
                return BadRequest("Invalid input");
            
            // location / status code 201 / resource
            return Ok();
        }
        [HttpPost]

        public IHttpActionResult PostOwner(PetOwner petOwner)
        {
            if()
        }
    }
}
