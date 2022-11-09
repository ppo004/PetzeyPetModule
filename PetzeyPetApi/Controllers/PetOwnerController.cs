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
        [HttpPost]
        [Route ("api/ProfilePic/add")]
        public IHttpActionResult AddProfilePicture(int OwnerID, string picUrl)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input");
            repo.AddProfilePic(OwnerID, picUrl);
            
            return Ok();
        }

       
        [Route("api/ProfilePic/delete/{id}")]
        public IHttpActionResult DeleteProfile(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input");
            repo.DeleteProfilePic(id);
            return Ok();
        }






        //[HttpPost]


    }
}
