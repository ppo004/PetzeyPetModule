using PetzeyPetBusinessLayer;
using PetzeyPetDataAccessLayer.PetOwnerRepository;
using PetzeyPetDTOs;
using PetzeyPetEntities;
using PetzeyPetExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using System.Data.Entity.Infrastructure;
using log4net;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace PetzeyPetApi.Controllers
{
    public class PetOwnerController : ApiController
    {
        

        IPetOwnerBll ownerbll;
        ILog log;
        public PetOwnerController(IPetOwnerBll ownerbll)
        {
            this.ownerbll = ownerbll;
            this.log = log4net.LogManager.GetLogger(typeof(PetController));
        }

        [Route("api/addOwner")]
        public IHttpActionResult PostOwner(AddOwnerDto petOwner)
        {
            try
            {
                log.Debug("Inside PostOwner of PetOwnerController");
                log.Debug($"Recieved Data is {JsonConvert.SerializeObject(petOwner)}");
                OwnerDto ownerDto = ownerbll.CreateOwner(petOwner);
                log.Debug($"Sent Data is {JsonConvert.SerializeObject(ownerDto)}");
                return Ok(ownerDto);
            }
            catch (IncorrectEmailFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectPhoneNoFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (DbUpdateException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectLocationFormat e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (EmptyFieldException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }

        }
        [Route("api/addOwnerAsync")]
        public async Task<IHttpActionResult> PostOwnerAsync(AddOwnerDto petOwner)
        {
            try
            {
                log.Debug("Inside PostOwnerAsync of PetOwnerController");
                log.Debug($"Recieved Data is {JsonConvert.SerializeObject(petOwner)}");
                OwnerDto ownerDto = await ownerbll.CreateOwnerAsync(petOwner);
                log.Debug($"Sent Data is {JsonConvert.SerializeObject(ownerDto)}");
                return Ok(ownerDto);
            }
            catch (IncorrectEmailFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectPhoneNoFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (DbUpdateException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectLocationFormat e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (EmptyFieldException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }

        }

        [Route("api/editOwner")]
        public IHttpActionResult PutOwner(OwnerDto petOwner)
        {
            try
            {
                log.Debug("Inside PutOwner of PetOwnerController");
                log.Debug($"Recieved Data is {JsonConvert.SerializeObject(petOwner)}");
                OwnerDto res = ownerbll.EditOwner(petOwner);
                log.Debug($"Sent Data is {JsonConvert.SerializeObject(res)}");
                return Ok(petOwner);
            }
            catch (DbUpdateException e) { log.Debug(e.Message); log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectPhoneNoFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectEmailFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectLocationFormat e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (EmptyFieldException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }
        }
        [Route("api/editOwnerAsync")]
        public async Task<IHttpActionResult> PutOwnerAsync(OwnerDto petOwner)
        {
            try
            {
                log.Debug("Inside PutOwnerAsync of PetOwnerController");
                log.Debug($"Recieved Data is {JsonConvert.SerializeObject(petOwner)}");
                OwnerDto res = await ownerbll.EditOwnerAsync(petOwner);
                log.Debug($"Sent Data is {JsonConvert.SerializeObject(res)}");
                return Ok(petOwner);
            }
            catch (DbUpdateException e) { log.Debug(e.Message); log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectPhoneNoFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectEmailFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (IncorrectLocationFormat e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (EmptyFieldException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                log.Debug("Inside GetOwner of PetOwnerController");
                log.Debug($"Recieved id is {JsonConvert.SerializeObject(id)}");
                OwnerDto ownerDto = ownerbll.GetOwnerById(id);
                log.Debug($"Sent Data is {JsonConvert.SerializeObject(ownerDto)}");
                return Ok(ownerDto);
            }
            catch(OwnerDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }
        }
        [HttpGet]
        [Route("api/PetOwner/{id}")]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            try
            {
                log.Debug("Inside GetOwnerAsync of PetOwnerController");
                log.Debug($"Recieved id is {JsonConvert.SerializeObject(id)}");
                OwnerDto ownerDto = await ownerbll.GetOwnerByIdAsync(id);
                log.Debug($"Sent Data is {JsonConvert.SerializeObject(ownerDto)}");
                return Ok(ownerDto);
            }
            catch (OwnerDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }
        }
        [HttpPut]
        [Route("api/addProfilePic")]
        public IHttpActionResult AddProfilePic(AddProfilePicDto dto)
        {
            try
            {
                log.Debug("Inside AddProfilePic of PetOwnerController");
                log.Debug($"Recieved id is {JsonConvert.SerializeObject(dto)}");
                PetOwner owner = ownerbll.AddOwnerProfilePic(dto);
                log.Debug($"Sent Data is {JsonConvert.SerializeObject(owner)}");
                return Ok(owner);
            }
            catch (IncorrectURLFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (OwnerDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }
        }
        [HttpPut]
        [Route("api/addProfilePicAsync")]
        public async Task<IHttpActionResult> AddProfilePicAsync(AddProfilePicDto dto)
        {
            try
            {
                log.Debug("Inside AddProfilePicAsync of PetOwnerController");
                log.Debug($"Recieved id is {JsonConvert.SerializeObject(dto)}");
                PetOwner owner = await ownerbll.AddOwnerProfilePicAsync(dto);
                log.Debug($"Sent Data is {JsonConvert.SerializeObject(owner)}");
                return Ok(owner);
            }
            catch (IncorrectURLFormatException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (OwnerDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }
        }

        [HttpPut]
        [Route("api/deleteProfilePic/{ownerID}")]
        public IHttpActionResult DeleteProfilePic(int ownerID)
        {
            try
            {
                log.Debug("Inside DeleteProfilePic of PetOwnerController");
                log.Debug($"Recieved id is {ownerID}");
                PetOwner owner = ownerbll.DeleteOwnerProfilePic(ownerID);
                log.Debug($"Sent Data is {JsonConvert.SerializeObject(owner)}");
                return Ok(owner);
            }
            catch (OwnerDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }

        }
        [HttpPut]
        [Route("api/deleteProfilePicAsync/{ownerID}")]
        public async Task<IHttpActionResult> DeleteProfilePicAsync(int ownerID)
        {
            try
            {
                log.Debug("Inside DeleteProfilePic of PetOwnerController");
                log.Debug($"Recieved id is {ownerID}");
                PetOwner owner = await ownerbll.DeleteOwnerProfilePicAsync(ownerID);
                log.Debug($"Sent Data is {JsonConvert.SerializeObject(owner)}");
                return Ok(owner);
            }
            catch (OwnerDoesntExistException e) { log.Debug(e.Message); return BadRequest(e.Message); }
            catch (Exception e)
            {
                log.Error(JsonConvert.SerializeObject(e));
                return InternalServerError();
            }

        }

        [System.Web.Http.HttpGet]
        [EnableQuery]
        public IQueryable<OwnerDto> GetAllPets()
        {
            return ownerbll.GetAllOwners().AsQueryable();
        }
    }
}
