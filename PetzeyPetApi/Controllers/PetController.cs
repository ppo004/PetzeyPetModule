using AutoMapper;
using log4net;
using Microsoft.AspNet.OData;
using Newtonsoft.Json;
using PetzeyPetBusinessLayer;
using PetzeyPetDTOs;
using PetzeyPetEntities;
using PetzeyPetExceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.Results;
using System.Web.Mvc;
using EnableQueryAttribute = Microsoft.AspNet.OData.EnableQueryAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace PetzeyPetApi.Controllers
{
    public class PetController : ApiController
    {
        IPetBll bll;
        ILog log;
        public PetController(IPetBll bll)
        {
            this.bll = bll;
            this.log = log4net.LogManager.GetLogger(typeof(PetController));
        }
        

        [Route("api/Pet/AddAppointment")]
        public IHttpActionResult AddAppointmentTopet(PetAppDto petAppDto)
        {
            try
            {
                log.Debug("Inside AddAppointmentTopetAsync of PetController");
                log.Debug($"Recieved Data is {JsonConvert.SerializeObject(petAppDto)} added appointment to pet");
                return Ok(bll.AddAppointmentsToPet(petAppDto));
               
            }
            catch (PetDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }
        }

        public IHttpActionResult PostPet(AddPetDto pet)
        {
            //log.Debug("Hello there debug");
            try
            {
                log.Debug("Inside PostPet of PetController");
                log.Debug($"Recieved Data is {JsonConvert.SerializeObject(pet)}");
                UpdatePetDto petDto = bll.CreatePet(pet);
                log.Debug($"Sent Data is {JsonConvert.SerializeObject(petDto)}");
                return Ok(petDto);
            }

            catch (EmptyFieldException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectBloodGroupFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (PetDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectDOBFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectURLFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (OwnerDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (SameOwnerSameNameException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e) {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }
        }

        public IHttpActionResult DeletePet(int id)
        {
            try
            {
                log.Debug("Inside DeletePet of PetController");
                log.Debug($"Recieved Data is {JsonConvert.SerializeObject(id)} performed deletion");
                return Ok(bll.DeletePet(id));
            }
            catch (PetDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }
        }

        public IHttpActionResult Putpet(UpdatePetDto pet)
        {
            try
            {
                log.Debug("Inside PutPet of PetController");
                log.Debug($"Recieved Data is {JsonConvert.SerializeObject(pet)} ");
                UpdatePetDto petDto = bll.EditPet(pet);
                log.Debug($"Sent Data is {JsonConvert.SerializeObject(petDto)}");
                return Ok(petDto);
            }
            catch (EmptyFieldException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectBloodGroupFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectDOBFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectURLFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (PetDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (OwnerDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (SameOwnerSameNameException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }
        }

        public IHttpActionResult GetPetById(int id)
        {
            try
            {
                log.Debug("Inside GetPetById of PetController");
                log.Debug($"Recieved Data is {JsonConvert.SerializeObject(id)}");
                UpdatePetDto petDto = bll.GetPetById(id);
                log.Debug($"Sent Data is {JsonConvert.SerializeObject(petDto)}");
                return Ok(petDto);
            }
            catch (PetDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }
        }


        [Route("api/Pet/Async")]
        public async Task<IHttpActionResult> PostPetAsync(AddPetDto pet)
        {
            try
            {
                log.Debug("Inside PostPetAsync of PetController");
                log.Debug($"Recieved Data is {JsonConvert.SerializeObject(pet)}");
                UpdatePetDto petDto = await bll.CreatePetAsync(pet);
                log.Debug($"Sent Data is {JsonConvert.SerializeObject(petDto)}");
                return Ok(petDto);
            }

            catch (IncorrectEmailFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (EmptyFieldException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectBloodGroupFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectDOBFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectURLFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (OwnerDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (PetDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (SameOwnerSameNameException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }
        }
        [Route("api/Pet/Async/{id}")]
        public async Task<IHttpActionResult> DeletePetAsync(int id)
        {
            try {
                log.Debug("Inside DeletePetAsync of PetController");
                log.Debug($"Recieved Data is {JsonConvert.SerializeObject(id)} performed deletion");

                return Ok(await bll.DeletePetAsync(id));
            }
            catch (PetDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }

        }
        [Route("api/Pet/Async")]
        public async Task<IHttpActionResult> PutpetAsync(UpdatePetDto pet)
        {
            try
            {
                log.Debug("Inside PutPetAsync of PetController");
                log.Debug($"Recieved Data is {JsonConvert.SerializeObject(pet)}");
                UpdatePetDto petDto = await bll.EditPetAsync(pet);
                log.Debug($"Sent Data is {JsonConvert.SerializeObject(petDto)}");
                return Ok(petDto);
            }
            catch (IncorrectEmailFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (EmptyFieldException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectBloodGroupFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectDOBFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectURLFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (PetDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (OwnerDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (SameOwnerSameNameException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }
        }
        [Route("api/Pet/Async/{id}")]
        public async Task<IHttpActionResult> GetPetByIdAsync(int id)
        {
            try
            {
                log.Debug("Inside GetPetByIdAsync of PetController");
                log.Debug($"Recieved Data is {JsonConvert.SerializeObject(id)}");
                UpdatePetDto petDto = await bll.GetPetByIdAsync(id);
                log.Debug($"Sent Data is {JsonConvert.SerializeObject(petDto)}");
                return Ok(petDto);
            }
            catch (PetDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }
        }

        [Route("api/Pet/AddAppointment/Async")]
        public async Task<IHttpActionResult> AddAppointmentTopetAsync(PetAppDto petAppDto)
        {
            try {
                log.Debug("Inside AddAppointmentTopetAsync of PetController");
                log.Debug($"Recieved Data is {JsonConvert.SerializeObject(petAppDto)} added appointment to pet");
                return Ok(await bll.AddAppointmentsToPetAsync(petAppDto));
            }
            catch (PetDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }
        }

        [System.Web.Http.HttpGet]           
        [EnableQuery]
        public IQueryable<UpdatePetDto> GetAllPets()
        {
           return bll.GetAllPets().AsQueryable();
        }

    }
}
    