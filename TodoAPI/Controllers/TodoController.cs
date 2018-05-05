using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new TodoItem { Name = "Integrate Auth0" });
                _context.SaveChanges();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            TodoItem todoItem = _context.TodoItems.Find(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }
    }
}