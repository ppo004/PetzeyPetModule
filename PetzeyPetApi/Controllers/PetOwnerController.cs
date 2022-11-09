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
        /*[HttpPost]
        [Route("api/add")]
        public IHttpActionResult Add(long OwnerID, string picUrl)
        {
            // validation
            if (!ModelState.IsValid)
                return BadRequest("Invalid input");

            // location / status code 201 / resource
            return Ok();
        }
*/
        [Route("api/addOwner")]
        public IHttpActionResult PostOwner(PetOwner petOwner)
        {
            if (repo.CreateOwner(petOwner))
            {
                return Ok();
            }
            else return BadRequest();
        }
        [Route("api/editOwner")]
        public IHttpActionResult Put(PetOwner petOwner)
        {
            repo.EditOwner(petOwner);
            return Ok();
        }
    }
}
