using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Controllers
{
    
    [Route("api/commands")]
    [ApiController]
    public class CommandsController: ControllerBase //inheritance with base controller 
    {
        private readonly ICommanderRepo _repository;

        public CommandsController(ICommanderRepo repository)
        {
            _repository =repository;
        }

        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        [HttpGet] //GET api/commands
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(commandItems);
        }

        [HttpGet("{id}") ] //GET api/commands/{id}
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommmandById(id);
            return Ok(commandItem);
        }
    }
}
