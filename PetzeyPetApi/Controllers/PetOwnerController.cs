﻿using PetzeyPetBusinessLayer;
using PetzeyPetDataAccessLayer.PetOwnerRepository;
using PetzeyPetDTOs;
using PetzeyPetEntities;
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
    public class PetOwnerController : ApiController
    {
        

        IPetOwnerBll ownerbll;
        public PetOwnerController(IPetOwnerBll ownerbll)
        {
            this.ownerbll = ownerbll;
        }

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

        [Route("api/editOwner")]
        public IHttpActionResult Put(EditOwnerDto petOwner)
        {
            ownerbll.EditOwner(petOwner);
            return Ok(petOwner);
        }

        public IHttpActionResult Get(int id)
        {
            EditOwnerDto ownerDto = ownerbll.GetOwnerById(id);
            if (ownerDto == null)
                return NotFound();
            return Ok(ownerDto);
        }
        [HttpPut]
        [Route("api/addProfilePic")]
        public IHttpActionResult AddProfilePic(AddProfilePicDto dto)
        {
            PetOwner owner = ownerbll.AddOwnerProfilePic(dto);
            if (owner == null) return BadRequest(); 
            else return Ok(owner);
        }

        [HttpPut]
        [Route("api/deleteProfilePic/{ownerID}")]
        public IHttpActionResult deleteProfilePic(int ownerID)
        {
            PetOwner owner = ownerbll.deleteOwnerProfilePic(ownerID);
            if (owner == null) return BadRequest();
            else return Ok(owner);
        }

        [System.Web.Http.HttpGet]
        [EnableQuery]
        public IQueryable<EditOwnerDto> GetAllPets()
        {

            return ownerbll.GetAllOwners().AsQueryable();
        }



        ///<summary>
        /// Async
        /// </summary>

        [Route("api/addOwner/Async")]
        public async Task<IHttpActionResult> PostOwnerAsync(AddOwnerDto petOwner)
        {
            EditOwnerDto ownerDto = await ownerbll.CreateOwnerAsync(petOwner);

            if (ownerDto == null)
            {
                return BadRequest();
            }
            else return Ok(ownerDto);
        }

        [Route("api/editOwner/Async")]
        public async Task<IHttpActionResult> PutAsync(EditOwnerDto petOwner)
        {
            await ownerbll.EditOwnerAsync(petOwner);
            return Ok(petOwner);
        }

        public async Task<IHttpActionResult> GetAsync(int id)
        {
            EditOwnerDto ownerDto = await ownerbll.GetOwnerByIdAsync(id);
            if (ownerDto == null)
                return NotFound();
            return Ok(ownerDto);
        }
        [HttpPut]
        [Route("api/addProfilePic/Async")]
        public async Task<IHttpActionResult> AddProfilePicAsync(AddProfilePicDto dto)
        {
            PetOwner owner = await ownerbll.AddOwnerProfilePicAsync(dto);
            if (owner == null) return BadRequest();
            else return Ok(owner);
        }

        [HttpPut]
        [Route("api/deleteProfilePic/Async/{ownerID}")]
        public async Task<IHttpActionResult> deleteProfilePicAsync(int ownerID)
        {
            PetOwner owner = await ownerbll.deleteOwnerProfilePicAsync(ownerID);
            if (owner == null) return BadRequest();
            else return Ok(owner);
        }

    }
}
