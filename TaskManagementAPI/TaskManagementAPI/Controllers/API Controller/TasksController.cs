using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = _context.Tasks.ToList();
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult CreateTask(TaskItem task)
        {
            task.CreatedDate = DateTime.Now;

            _context.Tasks.Add(task);
            _context.SaveChanges();

            return Ok(task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, TaskItem task)
        {
            var existingTask = _context.Tasks.Find(id);

            if (existingTask == null)
                return NotFound();

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;

            _context.SaveChanges();

            return Ok(existingTask);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task == null)
                return NotFound();

            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return Ok();
        }
    }
}