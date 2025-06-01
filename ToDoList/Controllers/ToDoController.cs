using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        ToDoTaskList list = ToDoTaskList.GetInstance();
        [HttpGet("GetTasks")]
        public IActionResult Get() 
        {
            if(list.Tasks.Count == 0) return NotFound();
            return Ok(list.Tasks);
        }

        [HttpPost("AddTask")]
        public IActionResult Add([FromBody] string text)
        {
            if(text == "") return BadRequest();
            ToDoItem item = new ToDoItem();
            item.Text = text;
            item.Id = Guid.NewGuid();
            list.Tasks.Add(item);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id) 
        {
            if(list.Tasks.Any(task => task.Id == id))
            {
                return Ok(list.Tasks.FirstOrDefault(t => t.Id == id));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] string text)
        {
            if (list.Tasks.Any(task => task.Id == id))
            {
                var task = list.Tasks.Single(t => t.Id == id);
                task.Text = text;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (list.Tasks.Any(task => task.Id == id))
            {
                var task = list.Tasks.Single(t => t.Id == id);
                list.Tasks.Remove(task);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
