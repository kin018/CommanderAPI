using AutoMapper;
using Commander.DTOs;
using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile  
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDTO>();//Source-> TargetDestination
            CreateMap<CommandCreateDTO, Command>();//Mapping from CommandReadDTO to Command Model
            CreateMap<CommandUpdateDTO,Command>();//Mapping from CommandUpdateDTO to Command Model
            CreateMap<Command, CommandUpdateDTO>();//Mapping from Command Model to CommandUpdateDTO(used for PATCH) *NOTE this needs to be explicity created even though previous line of code is mapped that way*
        }
    }
}
