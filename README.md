The following are the apis exposed by this module

Owner APIs

GET : OwnerDetails (using OData)
POST : CreateOwner(OwnerDetails)
PUT : EditOwner(OwnerDetails)
POST : AddProfilePicture(OwnerID, picUrl)
DELETE : DeleteProfilePicture(OwnerID)

Pet APIs

GET : PetDetails (using Odata)
POST : CreatePet(PetDetails)
DELETE : DeletePet(PetId)
PUT : EditPet(PetDetails)
POST : AddAppointmentIDToPet(petId, AppointmentID)