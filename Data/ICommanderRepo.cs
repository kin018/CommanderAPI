﻿using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        //give me a list of all command objects
       IEnumerable<Command> GetAllCommands();
       Command GetCommmandById(int id);//return a single command back to user by provided id 



    }
}