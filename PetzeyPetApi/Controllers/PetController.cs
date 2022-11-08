using AutoMapper;
using PetzeyPetBusinessLayer;
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
        PetBll bll = new PetBll();

        public IHttpActionResult PostPet(AddPetDto pet)
        {
            PetDto petDto = bll.CreatePet(pet);
            if (petDto == null)
                return BadRequest();
            return Ok(petDto);
        }

        public IHttpActionResult DeletePet(int id)
        {
            if (bll.DeletePet(id))
                return Ok();
            return BadRequest();
        }

        public IHttpActionResult Putpet(PetDto pet)
        {
            PetDto petDto = bll.EditPet(pet);
            if (petDto == null)
                return BadRequest();
            return Ok(petDto);


        }

        public IHttpActionResult GetPetById(int id)
        {
            PetDto petDto = bll.GetPetById(id);
            if (petDto == null)
                return NotFound();
            return Ok(petDto);
        }

    }
}
    