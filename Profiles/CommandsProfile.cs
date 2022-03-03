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
        }
    }
}
