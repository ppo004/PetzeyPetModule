using PetzeyPetBusinessLayer;
using PetzeyPetDataAccessLayer.PetOwnerRepository;
using PetzeyPetDTOs;
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
        //private IPetOwnerRepository repo=new PetOwnerRepository();
        PetOwnerBll ownerbll=new PetOwnerBll();
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
        public IHttpActionResult PostOwner(AddOwnerDto petOwner)
        {
           EditOwnerDto ownerDto = ownerbll.CreateOwner(petOwner);
            
           if (ownerDto==null)
            {
                return BadRequest();
            }
            else return Ok(ownerDto);
        }
        /*[Route("api/editOwner")]
        public IHttpActionResult Put(PetOwner petOwner)
        {
            repo.EditOwner(petOwner);
            return Ok();
        }*/
        public IHttpActionResult Get(int id)
        {
            EditOwnerDto ownerDto = ownerbll.GetOwnerById(id);
            if (ownerDto == null)
                return NotFound();
            return Ok(ownerDto);
        }
    }
}
