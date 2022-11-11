﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PetzeyPetBusinessLayer;
using Moq;
using PetzeyPetDataAccessLayer;
using PetzeyPetDataAccessLayer.PetOwnerRepository;
using PetzeyPetDTOs;
using PetzeyPetExceptions;
using PetzeyPetEntities;

namespace PetzeyPetUnitTests
{
   //[TestClass]
    public class PetOwnerBllUnitTest
    {
        IPetOwnerBll ownerBll;
        public PetOwnerBllUnitTest()
        {
            ownerBll = new PetOwnerBll();           
        }
        [TestMethod,ExpectedException(typeof(IncorrectEmailFormatException))]
        public void IncorrectEmailTest()
        {
            AddOwnerDto addOwnerDto = new AddOwnerDto();
            addOwnerDto.OwnerEmail = "dummy";
            ownerBll.CreateOwner(addOwnerDto);
        }
        [TestMethod, ExpectedException(typeof(IncorrectPhoneNoFormatException))]
        public void IncorrectPhoneNumberTest()
        {
            AddOwnerDto addOwnerDto = new AddOwnerDto();
            addOwnerDto.OwnerEmail = "dummy1234@gmail.com`";
            addOwnerDto.OwnerPhone = "987654321";
            ownerBll.CreateOwner(addOwnerDto);
        }
        [TestMethod, ExpectedException(typeof(IncorrectURLFormatException))]
        public void IncorrectImageUrl()
        {
            AddOwnerDto addOwnerDto = new AddOwnerDto();
            addOwnerDto.OwnerEmail = "dummy1234@gmail.com";
            addOwnerDto.OwnerPhone = "9876543210";
            addOwnerDto.ImageUrl = "dkfdg";
            ownerBll.CreateOwner(addOwnerDto);
        }
        [TestMethod]
        public void AddOwnerSuccessfully()
        {
            Mock<IPetOwnerRepository> petRepoMock = new Mock<IPetOwnerRepository>();
            PetOwner owner = new PetOwner();
            owner.OwnerEmail = "abcdefhg@gmail.com";owner.OwnerPhone = "9876543321";owner.OwnerName = "Dummylal Singh";owner.PetOwnerId = 1;owner.OwnerLocation = "ssfsf";owner.ImageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
            petRepoMock.Setup(p => p.CreateOwner(owner)).Returns(owner);
            AddOwnerDto dto = new AddOwnerDto();
            dto.OwnerEmail = "abcdefhg@gmail.com"; dto.OwnerPhone = "9876543321"; dto.OwnerName = "Dummylal Singh"; dto.OwnerLocation = "ssfsf"; dto.ImageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
            OwnerDto res =  ownerBll.CreateOwner(dto);
            Assert.IsInstanceOfType(res, typeof(OwnerDto));
        }
        [TestMethod]
        public void EditOwnerSuccessfully()
        {
            Mock<IPetOwnerRepository> petRepoMock = new Mock<IPetOwnerRepository>();
            PetOwner owner = new PetOwner();
            owner.OwnerEmail = "abcdef@gmail.com"; owner.OwnerPhone = "9876543210"; owner.OwnerName = "Dummylal Singh"; owner.PetOwnerId = 1; owner.OwnerLocation = "ssfsf"; owner.ImageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
            petRepoMock.Setup(p=>p.EditOwner(owner)).Returns(owner);
            OwnerDto dto = new OwnerDto();dto.PetOwnerId = 1;
            dto.OwnerEmail = "abcdefh@gmail.com"; dto.OwnerPhone = "9876543211"; dto.OwnerName = "Dummylal Singh"; dto.OwnerLocation = "ssfsf"; dto.ImageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
            OwnerDto res = ownerBll.EditOwner(dto);
            Assert.IsInstanceOfType(res, typeof(OwnerDto));
        }
        [TestMethod,ExpectedException(typeof(IncorrectURLFormatException))]
        public void IncorrectProfilePicTest()
        {
            AddProfilePicDto dto = new AddProfilePicDto();
            dto.OwnerId = 1;dto.imageUrl = "fsffsfs";
            ownerBll.AddOwnerProfilePic(dto);
        }
        [TestMethod]
        public void AddProfilePicTest()
        {
            Mock<IPetOwnerRepository> petRepoMock = new Mock<IPetOwnerRepository>();
            AddProfilePicDto dto = new AddProfilePicDto(); dto.OwnerId = 1; dto.imageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
            PetOwner owner = new PetOwner();
            owner.OwnerEmail = "abcdef@gmail.com"; owner.OwnerPhone = "9876543210"; owner.OwnerName = "Dummylal Singh"; owner.PetOwnerId = 1; owner.OwnerLocation = "ssfsf"; owner.ImageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
            petRepoMock.Setup(p => p.AddProfilePic(1, "gdgdgdg")).Returns(owner);
            PetOwner owner1 =  ownerBll.AddOwnerProfilePic(dto);
            Assert.IsInstanceOfType(owner1, typeof(PetOwner));
        }
        [TestMethod]
        public void DeleteProfile()
        {
            Mock<IPetOwnerRepository> petRepoMock = new Mock<IPetOwnerRepository>();
            petRepoMock.Setup(p => p.DeleteProfilePic(1)).Returns(new PetOwner());
            PetOwner owner = ownerBll.DeleteOwnerProfilePic(1);
            Assert.IsInstanceOfType(owner, typeof(PetOwner));   
        }
        [TestMethod, ExpectedException(typeof(IncorrectEmailFormatException))]
        public async void IncorrectEmailTestAsync()
        {
            AddOwnerDto addOwnerDto = new AddOwnerDto();
            addOwnerDto.OwnerEmail = "dummy";
            await ownerBll.CreateOwnerAsync(addOwnerDto);
        }
        [TestMethod, ExpectedException(typeof(IncorrectPhoneNoFormatException))]
        public async void IncorrectPhoneNumberTestAsync()
        {
            AddOwnerDto addOwnerDto = new AddOwnerDto();
            addOwnerDto.OwnerEmail = "dummy1234@gmail.com`";
            addOwnerDto.OwnerPhone = "987654321";
            await ownerBll.CreateOwnerAsync(addOwnerDto);
        }
        [TestMethod, ExpectedException(typeof(IncorrectURLFormatException))]
        public async void IncorrectImageUrlAsync()
        {
            AddOwnerDto addOwnerDto = new AddOwnerDto();
            addOwnerDto.OwnerEmail = "dummy1234@gmail.com";
            addOwnerDto.OwnerPhone = "9876543210";
            addOwnerDto.ImageUrl = "dkfdg";
            await ownerBll.CreateOwnerAsync(addOwnerDto);
        }
        [TestMethod]
        public async void AddOwnerSuccessfullyAsync()
        {
            Mock<IPetOwnerRepository> petRepoMock = new Mock<IPetOwnerRepository>();
            PetOwner owner = new PetOwner();
            owner.OwnerEmail = "abcdef@gmail.com"; owner.OwnerPhone = "9876543210"; owner.OwnerName = "Dummylal Singh"; owner.PetOwnerId = 1; owner.OwnerLocation = "ssfsf"; owner.ImageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
            petRepoMock.Setup(p => p.CreateOwner(owner)).Returns(owner);
            AddOwnerDto dto = new AddOwnerDto();
            dto.OwnerEmail = "abcdef@gmail.com"; dto.OwnerPhone = "9876543210"; dto.OwnerName = "Dummylal Singh"; dto.OwnerLocation = "ssfsf"; dto.ImageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
            OwnerDto res = await ownerBll.CreateOwnerAsync(dto);
            Assert.IsInstanceOfType(res, typeof(OwnerDto));
        }
        [TestMethod]
        public async void EditOwnerSuccessfullyAsync()
        {
            Mock<IPetOwnerRepository> petRepoMock = new Mock<IPetOwnerRepository>();
            PetOwner owner = new PetOwner();
            owner.OwnerEmail = "abcdef@gmail.com"; owner.OwnerPhone = "9876543210"; owner.OwnerName = "Dummylal Singh"; owner.PetOwnerId = 1; owner.OwnerLocation = "ssfsf"; owner.ImageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
            petRepoMock.Setup(p => p.EditOwner(owner)).Returns(owner);
            OwnerDto dto = new OwnerDto(); dto.PetOwnerId = 1;
            dto.OwnerEmail = "abcdefh@gmail.com"; dto.OwnerPhone = "9876543211"; dto.OwnerName = "Dummylal Singh"; dto.OwnerLocation = "ssfsf"; dto.ImageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
            OwnerDto res = await ownerBll.EditOwnerAsync(dto);
            Assert.IsInstanceOfType(res, typeof(OwnerDto));
        }
        [TestMethod, ExpectedException(typeof(IncorrectURLFormatException))]
        public async void IncorrectProfilePicTestAsync()
        {
            AddProfilePicDto dto = new AddProfilePicDto();
            dto.OwnerId = 1; dto.imageUrl = "fsffsfs";
            await ownerBll.AddOwnerProfilePicAsync(dto);
        }
        [TestMethod]
        public async void AddProfilePicTestAsync()
        {
            Mock<IPetOwnerRepository> petRepoMock = new Mock<IPetOwnerRepository>();
            AddProfilePicDto dto = new AddProfilePicDto(); dto.OwnerId = 1; dto.imageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
            PetOwner owner = new PetOwner();
            owner.OwnerEmail = "abcdef@gmail.com"; owner.OwnerPhone = "9876543210"; owner.OwnerName = "Dummylal Singh"; owner.PetOwnerId = 1; owner.OwnerLocation = "ssfsf"; owner.ImageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
            petRepoMock.Setup(p => p.AddProfilePic(1, "gdgdgdg")).Returns(owner);
            PetOwner owner1 = await ownerBll.AddOwnerProfilePicAsync(dto);
            Assert.IsInstanceOfType(owner1, typeof(PetOwner));
        }
        [TestMethod]
        public async void DeleteProfileAsync()
        {
            Mock<IPetOwnerRepository> petRepoMock = new Mock<IPetOwnerRepository>();
            petRepoMock.Setup(p => p.DeleteProfilePic(1)).Returns(new PetOwner());
            PetOwner owner = await ownerBll.DeleteOwnerProfilePicAsync(1);
            Assert.IsInstanceOfType(owner, typeof(PetOwner));
        }
    }
}
