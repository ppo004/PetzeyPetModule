using AutoMapper;
using PetzeyPetBusinessLayer;
using PetzeyPetDTOs;
using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            UpdatePetDto petDto = bll.CreatePet(pet);
            if (petDto == null)
                return BadRequest();
            return Ok(petDto);
        }
        //public async Task<IHttpActionResult> PostPetAsync(AddPetDto pet)
        //{
        //    UpdatePetDto petDto = await bll.CreatePet(pet);
        //    if (petDto == null)
        //        return BadRequest();
        //    return Ok(petDto);
        //}
        public IHttpActionResult DeletePet(int id)
        {
            if (bll.DeletePet(id))
                return Ok();
            return BadRequest();
        }

        public IHttpActionResult Putpet(UpdatePetDto pet)
        {
            UpdatePetDto petDto = bll.EditPet(pet);
            if (petDto == null)
                return BadRequest();
            return Ok(petDto);
        }

        public IHttpActionResult GetPetById(int id)
        {
            UpdatePetDto petDto = bll.GetPetById(id);
            if (petDto == null)
                return NotFound();
            return Ok(petDto);
        }

    }
}
    