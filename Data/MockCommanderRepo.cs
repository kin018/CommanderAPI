using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo //Implements ICommanderRepo interface
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command { Id = 0, HowTo = "Boil and egg", Line = "Boil Water", Platform= "Kettle & Pan" },
                new Command { Id = 0, HowTo = "Cut Bread", Line = "Grab Knife", Platform= "Knife" },                
                new Command { Id = 0, HowTo = "Make a cup of tea", Line = "Grab Spoon", Platform= "Spoon" }
            };

            return commands;
        }

        public Command GetCommmandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil Water", Platform= "Kettle & Pan" };
        }
    }
}
