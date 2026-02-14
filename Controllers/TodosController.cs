using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Danan_TodoList.Models;
using Danan_TodoList.Data;

namespace Danan_TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TodosController(AppDbContext context)
        {
            _context = context;
        }

        //CREATE TODO
        [HttpPost]
        public async Task<IActionResult> CreateTodo(Todo todo)
        {
            if (string.IsNullOrWhiteSpace(todo.Title))
            
                return BadRequest("Title is required.");
            
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id }, todo);
        }

        //GET ALL TODOS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            return await _context.Todos.ToListAsync();
        }

        //GET TODO BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodoById(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return todo;
        }

        //UPDATE TODO MARK AS COMPLETED
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteTodo(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
                return NotFound();
            
            todo.IsCompleted = true;
            await _context.SaveChangesAsync();

            return Ok(todo);
        }

        //DELETE TODO
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
                return NotFound();

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}