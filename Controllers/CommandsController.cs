using AutoMapper;
using Commander.Data;
using Commander.DTOs;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase //inheritance with base controller 
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet] //GET api/commands
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(commandItems);
        }

        [HttpGet("{id}", Name = "GetCommandById")] //GET api/commands/{id}
        public ActionResult<CommandReadDTO> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommmandById(id);
            if (commandItem != null) //checks if commmandItem is null or not
            {
                return Ok(_mapper.Map<CommandReadDTO>(commandItem));
            }
            return NotFound();
        }

        [HttpPost] //POST api/commands
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO commandCreateDTO)// returns back a ReadDTO called CreateCommand that takes as an input a commandCreateDTO
        {
            var commandModel = _mapper.Map<Command>(commandCreateDTO);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDTO = _mapper.Map<CommandReadDTO>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDTO.Id }, commandReadDTO); //CreatedAtRoute
        }

        [HttpPut("{id}")] //PUT api/commands/{id}
        public ActionResult UpdateCommand(int id, CommandUpdateDTO commandUpdateDTO)
        {
            //placeholder to check if resource exist or not
            var commandModelFromRepo = _repository.GetCommmandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDTO, commandModelFromRepo); //both contain data so we use this syntax of existing source to new destination object(from UpdateDTO to commmandModelFromRepo to be updated and tracked by dbcontext )

            _repository.UpdateCommand(commandModelFromRepo); //call update method to repo and supply in commandModelFromRepo because other implementations may require this 

            _repository.SaveChanges(); //saves changes to DB

            return NoContent();
        }

        [HttpPatch("{id}")] //PATCH api/commands/{id}

        //Get Patch document from our request-> Check resource to update from repo->Generate an empty command on the DTO and use Data from repository model-> validate with if statement-> apply patch
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDTO> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommmandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDTO>(commandModelFromRepo); //applies patch to this variable from the source commandModelFromRepo
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")] //DELETE api/commands/{id}
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommmandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
