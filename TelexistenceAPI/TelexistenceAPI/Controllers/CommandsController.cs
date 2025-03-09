using Microsoft.AspNetCore.Mvc;
using TelexistenceAPI.Models;
using System.Linq;
using System.Collections.Generic;

namespace TelexistenceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommandsController : ControllerBase
    {
        private static List<Command> commands = new List<Command>();

        [HttpPost]
        public IActionResult PostCommand([FromBody] Command command)
        {
            command.Id = System.Guid.NewGuid().ToString();
            command.Timestamp = System.DateTime.UtcNow;
            commands.Add(command);
            return Ok(command);
        }

        [HttpGet]
        public IActionResult GetCommands()
        {
            return Ok(commands);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCommand(string id, [FromBody] Command updatedCommand)
        {
            var command = commands.FirstOrDefault(c => c.Id == id);
            if (command == null)
                return NotFound();

            command.CommandText = updatedCommand.CommandText;
            return Ok(command);
        }

        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            return Ok(new { Status = "Operational", Time = System.DateTime.UtcNow });
        }

        [HttpGet("history")]
        public IActionResult GetHistory()
        {
            return Ok(commands);
        }
    }
}
