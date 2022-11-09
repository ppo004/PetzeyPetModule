using AutoMapper;
using PetzeyPetDataAccessLayer;
using PetzeyPetDTOs;
using PetzeyPetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzeyPetBusinessLayer
{
    public class PetBllAsync
    {
       

        MapperConfiguration config = new MapperConfiguration(cfg =>

                  cfg.CreateMap<AddPetDto, Pet>().ForMember(dest => dest.AppointmentIds, act => act.Ignore())

              );
        MapperConfiguration config1 = new MapperConfiguration(cfg =>

                 cfg.CreateMap<UpdatePetDto, Pet>()

             );
        MapperConfiguration config2 = new MapperConfiguration(cfg =>

                 cfg.CreateMap<Pet, UpdatePetDto>()

             );

        

    }
}

