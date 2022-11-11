using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetzeyPetBusinessLayer;
using PetzeyPetDTOs;
using PetzeyPetEntities;
using PetzeyPetExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetUnitTests
{
    [TestClass]
    public class PetBllUnitTest
    {
        IPetBll bll = new PetBll();
        
        [TestMethod, ExpectedException(typeof(IncorrectURLFormatException))]
        public void IncorrectImageUrl()
        {
            AddPetDto addPetDto = new AddPetDto();
            addPetDto.OwnerId = 2;
            addPetDto.Name = "doggo";
            addPetDto.Species = "string";
            addPetDto.Gender = "male";
            addPetDto.DOB = DateTime.Now;
            addPetDto.IsNeutured = true;
            addPetDto.BloodGroup = "A+";
            addPetDto.Breed = "String";
            addPetDto.Allergies = new List<string>() { };
            addPetDto.ImageUrl = "qwwqe";
            
        }

        [TestMethod, ExpectedException(typeof(IncorrectBloodGroupFormatException))]
        public void IncorrectBloodGrp()
        {
            AddPetDto addPetDto = new AddPetDto();
            addPetDto.BloodGroup = "h-";
            addPetDto.Allergies = null;
            addPetDto.Breed = "dsda";
            addPetDto.Gender = "m";
            addPetDto.IsNeutured = true;
            addPetDto.DOB = DateTime.Now;
            addPetDto.Name = "doggo";
            addPetDto.OwnerId = 3;
            addPetDto.Species = "dog";
            addPetDto.ImageUrl = "https://adsad.com";

            bll.CreatePet(addPetDto);
        }

        [TestMethod, ExpectedException(typeof(EmptyFieldException))]
        public void OwnerDoesntExist()
        {
            AddPetDto addPetDto = new AddPetDto();
            addPetDto.BloodGroup = "";
            addPetDto.Allergies = null;
            addPetDto.Breed = "";
            addPetDto.Gender = "";
            addPetDto.IsNeutured = true;
            addPetDto.DOB = DateTime.Now;
            addPetDto.Name = "";
            addPetDto.OwnerId = 0;
            addPetDto.Species = "";
            addPetDto.ImageUrl = "";

            bll.CreatePet(addPetDto);
        }

        [TestMethod, ExpectedException(typeof(IncorrectDOBFormatException))]
        public void IncorrectDOB()
        {
            AddPetDto addPetDto = new AddPetDto();
            addPetDto.BloodGroup = "a+";
            addPetDto.Allergies = null;
            addPetDto.Breed = "dsda";
            addPetDto.Gender = "m";
            addPetDto.IsNeutured = true;
            addPetDto.DOB = DateTime.MaxValue;
            addPetDto.Name = "doggo";
            addPetDto.OwnerId = 3;
            addPetDto.Species = "dog";
            addPetDto.ImageUrl = "https://adsad.com";

            bll.CreatePet(addPetDto);
        }
       
    }
}
