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
        private readonly ToDoContext _context;
        public ToDoController(ToDoContext context)
        {
            _context = context;
        }

        [HttpGet("GetTasks")]
        public IActionResult Get() 
        {
            var tasks = _context.ToDoItems.ToList();
            if(tasks.Count == 0) return NotFound();
            return Ok(tasks);
        }

        [HttpPost("AddTask")]
        public IActionResult Add([FromBody] string text)
        {
            if(text == "") return BadRequest();
            ToDoItem item = new ToDoItem();
            item.Text = text;
            item.Id = Guid.NewGuid();
            _context.ToDoItems.Add(item);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id) 
        {
            var task = _context.ToDoItems.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] string text)
        {
            if (text == "") return BadRequest();
            var task = _context.ToDoItems.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();
            task.Text = text;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var task = _context.ToDoItems.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();
            _context.ToDoItems.Remove(task);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
