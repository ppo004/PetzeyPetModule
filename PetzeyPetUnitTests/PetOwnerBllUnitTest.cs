using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PetzeyPetBusinessLayer;
using Moq;
using PetzeyPetDataAccessLayer;
using PetzeyPetDataAccessLayer.PetOwnerRepository;
using PetzeyPetDTOs;
using PetzeyPetExceptions;
using PetzeyPetEntities;
using System.Threading.Tasks;

namespace PetzeyPetUnitTests
{
    [TestClass]
    public class PetOwnerBllUnitTest
    {
        IPetOwnerBll ownerBll;
        AddOwnerDto addOwnerDto;
        [TestInitialize]
        public void Initialise()
        {
            ownerBll = new PetOwnerBll();

        }
        [TestMethod, ExpectedException(typeof(EmptyFieldException))]
        public void EmptyfieldTest()
        {
            addOwnerDto = new AddOwnerDto();
            ownerBll.CreateOwner(addOwnerDto);
        }
        [TestMethod,ExpectedException(typeof(IncorrectEmailFormatException))]
        public void IncorrectEmailTest()
        {
            addOwnerDto = new AddOwnerDto();
            addOwnerDto.OwnerEmail = "invalid";addOwnerDto.OwnerName = "name";addOwnerDto.OwnerPhone = "9876543210";addOwnerDto.OwnerLocation = "https://goo.gl/maps/WRmv6ec8sTuZ8Z7y9";addOwnerDto.ImageUrl = "https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg";
            ownerBll.CreateOwner(addOwnerDto);
        }
        [TestMethod, ExpectedException(typeof(IncorrectPhoneNoFormatException))]
        public void IncorrectPhoneNumberTest()
        {
            addOwnerDto = new AddOwnerDto();
            addOwnerDto.OwnerEmail = "abcdefgh@gmail.com"; addOwnerDto.OwnerName = "name"; addOwnerDto.OwnerPhone = "987654321"; addOwnerDto.OwnerLocation = "https://goo.gl/maps/WRmv6ec8sTuZ8Z7y9"; addOwnerDto.ImageUrl = "https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg";
            ownerBll.CreateOwner(addOwnerDto);
        }
        [TestMethod, ExpectedException(typeof(IncorrectURLFormatException))]
        public void IncorrectImageUrl()
        {
            AddOwnerDto addOwnerDto = new AddOwnerDto();
            addOwnerDto.OwnerEmail = "abcdefghe@gmail.com"; addOwnerDto.OwnerName = "name"; addOwnerDto.OwnerPhone = "8876543210"; addOwnerDto.OwnerLocation = "https://goo.gl/maps/WRmv6ec8sTuZ8Z7y9"; addOwnerDto.ImageUrl = "htts://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__48";
            ownerBll.CreateOwner(addOwnerDto);
        }
        [TestMethod]
        public void AddOwnerSuccessfully()
        {
            Mock<IPetOwnerRepository> petRepoMock = new Mock<IPetOwnerRepository>();
            PetOwner owner = new PetOwner();
            owner.OwnerEmail = "qwerty@gmail.com";owner.OwnerPhone = "7987654321";owner.OwnerName = "name";owner.PetOwnerId = 1;owner.OwnerLocation = "ssfsf";owner.ImageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
            petRepoMock.Setup(p => p.CreateOwner(owner)).Returns(owner);
            AddOwnerDto dto = new AddOwnerDto();
            dto.OwnerEmail = "qwerty@gmail.com"; dto.OwnerPhone = "7987654321"; dto.OwnerName = "Dummylal Singh"; dto.OwnerLocation = "ssfsf"; dto.ImageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
            Assert.IsInstanceOfType(ownerBll.CreateOwner(dto), typeof(OwnerDto));
        }
        [TestMethod]
        public void EditOwnerSuccessfully()
        {
            Mock<IPetOwnerRepository> petRepoMock = new Mock<IPetOwnerRepository>();
            PetOwner owner = new PetOwner();
            owner.OwnerEmail = "qwerty@gmail.com"; owner.OwnerPhone = "7987654321"; owner.OwnerName = "name"; owner.PetOwnerId = 1; owner.OwnerLocation = "ssfsf"; owner.ImageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
            petRepoMock.Setup(p=>p.EditOwner(owner)).Returns(owner);
            OwnerDto dto = new OwnerDto();dto.PetOwnerId = 1;
            dto.OwnerEmail = "qwerty@gmail.com"; dto.OwnerPhone = "7987654321"; dto.OwnerName = "Dummylal Singh"; dto.OwnerLocation = "ssfsf"; dto.ImageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
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
        public async Task IncorrectEmailTestAsync()
        {
            addOwnerDto = new AddOwnerDto();
            addOwnerDto.OwnerEmail = "invalid"; addOwnerDto.OwnerName = "name"; addOwnerDto.OwnerPhone = "9876543210"; addOwnerDto.OwnerLocation = "https://goo.gl/maps/WRmv6ec8sTuZ8Z7y9"; addOwnerDto.ImageUrl = "https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg";
            await ownerBll.CreateOwnerAsync(addOwnerDto);
        }
        [TestMethod, ExpectedException(typeof(IncorrectPhoneNoFormatException))]
        public async Task IncorrectPhoneNumberTestAsync()
        {
            addOwnerDto = new AddOwnerDto();
            addOwnerDto.OwnerEmail = "abcdefgh@gmail.com"; addOwnerDto.OwnerName = "name"; addOwnerDto.OwnerPhone = "987654321"; addOwnerDto.OwnerLocation = "https://goo.gl/maps/WRmv6ec8sTuZ8Z7y9"; addOwnerDto.ImageUrl = "https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg";
            await ownerBll.CreateOwnerAsync(addOwnerDto);
        }
        [TestMethod, ExpectedException(typeof(IncorrectURLFormatException))]
        public async Task IncorrectImageUrlAsync()
        {
            AddOwnerDto addOwnerDto = new AddOwnerDto();
            addOwnerDto.OwnerEmail = "abcdefghe@gmail.com"; addOwnerDto.OwnerName = "name"; addOwnerDto.OwnerPhone = "8876543210"; addOwnerDto.OwnerLocation = "https://goo.gl/maps/WRmv6ec8sTuZ8Z7y9"; addOwnerDto.ImageUrl = "htts://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__48";
            await ownerBll.CreateOwnerAsync(addOwnerDto);
        }
        [TestMethod]
        public async Task AddOwnerSuccessfullyAsync()
        {
            Mock<IPetOwnerRepository> petRepoMock = new Mock<IPetOwnerRepository>();
            PetOwner owner = new PetOwner();
            owner.OwnerEmail = "qwerty1@gmail.com"; owner.OwnerPhone = "7987654421"; owner.OwnerName = "name"; owner.PetOwnerId = 1; owner.OwnerLocation = "ssfsf"; owner.ImageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
            petRepoMock.Setup(p => p.CreateOwner(owner)).Returns(owner);
            AddOwnerDto dto = new AddOwnerDto();
            dto.OwnerEmail = "qwerty1@gmail.com"; dto.OwnerPhone = "7987654421"; dto.OwnerName = "name"; dto.OwnerLocation = "ssfsf"; dto.ImageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
            OwnerDto res = await ownerBll.CreateOwnerAsync(dto);
            Assert.IsInstanceOfType(res, typeof(OwnerDto));
        }
        [TestMethod]
        public async Task EditOwnerSuccessfullyAsync()
        {
            Mock<IPetOwnerRepository> petRepoMock = new Mock<IPetOwnerRepository>();
            PetOwner owner = new PetOwner();
            owner.OwnerEmail = "qwerty@gmail.com"; owner.OwnerPhone = "7987654321"; owner.OwnerName = "name"; owner.PetOwnerId = 1; owner.OwnerLocation = "ssfsf"; owner.ImageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
            petRepoMock.Setup(p=>p.EditOwner(owner)).Returns(owner);
            OwnerDto dto = new OwnerDto();dto.PetOwnerId = 1;
            dto.OwnerEmail = "qwerty@gmail.com"; dto.OwnerPhone = "7987654321"; dto.OwnerName = "Dummylal Singh"; dto.OwnerLocation = "ssfsf"; dto.ImageUrl = "https://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg";
            OwnerDto res = await ownerBll.EditOwnerAsync(dto);
            Assert.IsInstanceOfType(res, typeof(OwnerDto));
        }
        [TestMethod, ExpectedException(typeof(IncorrectURLFormatException))]
        public async Task IncorrectProfilePicTestAsync()
        {
            AddProfilePicDto dto = new AddProfilePicDto();
            dto.OwnerId = 1; dto.imageUrl = "fsffsfs";
            await ownerBll.AddOwnerProfilePicAsync(dto);
        }
        [TestMethod]
        public async Task AddProfilePicTestAsync()
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
        public async Task DeleteProfileAsync()
        {
            Mock<IPetOwnerRepository> petRepoMock = new Mock<IPetOwnerRepository>();
            petRepoMock.Setup(p => p.DeleteProfilePic(1)).Returns(new PetOwner());
            PetOwner owner = await ownerBll.DeleteOwnerProfilePicAsync(1);
            Assert.IsInstanceOfType(owner, typeof(PetOwner));
        }
    }
}
