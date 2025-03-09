using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskList.Api.Data;
using TaskList.Api.Dtos;
using TaskList.Api.Models;

namespace TaskList.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskListDbContext _context;

        public TasksController(TaskListDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyTaskDto>>> GetTasks()
        {
            var tasks = await _context.MyTasks.ToListAsync();

            var taskDto = tasks.Select(t => new MyTaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted
            });

            return Ok(taskDto);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MyTaskDto>>> GetTasks(int id)
        {
            var tasks = await _context.MyTasks.FindAsync(id);
            if (tasks == null) return NotFound();
            var taskDto = new MyTaskDto
            {
                Id = tasks.Id,
                Title = tasks.Title,
                Description = tasks.Description,
                IsCompleted = tasks.IsCompleted
            };
            return Ok(taskDto);
        }
        [HttpPost]
        public async Task<ActionResult<MyTaskDto>> CreateTask(MyTaskDto newTaskDto)
        {
            var task = new MyTask
            {
                Title = newTaskDto.Title,
                Description = newTaskDto.Description,
                IsCompleted = newTaskDto.IsCompleted
            };
            _context.MyTasks.Add(task);
            await _context.SaveChangesAsync();

            newTaskDto.Id = task.Id;

            return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, newTaskDto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<MyTaskDto>> EditTask(int id, MyTaskDto newTaskDto)
        {
            var task = _context.MyTasks.Find(id);
            if (task == null) return NotFound();

            task.Title = newTaskDto.Title;
            task.Description = newTaskDto.Description;
            task.IsCompleted = newTaskDto.IsCompleted;

            _context.MyTasks.Update(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var task = _context.MyTasks.Find(id);

            if (task == null) return NotFound();

            _context.MyTasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
