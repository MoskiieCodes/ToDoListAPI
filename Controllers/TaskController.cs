using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly TaskService taskService;

    public TasksController(TaskService taskService)
    {
        this.taskService = taskService;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(taskService.GetTasks());

    [HttpGet("pending")]
    public IActionResult GetPending() => Ok(taskService.GetTasks(false));

    [HttpGet("completed")]
    public IActionResult GetCompleted() => Ok(taskService.GetTasks(true));

    [HttpPost]
    public IActionResult Create(TaskItem task)
    {
        taskService.AddTask(task.Title, task.Description, task.DueDate, task.Priority);
        return CreatedAtAction(nameof(GetAll), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, TaskItem updated)
    {
        updated.Id = id;
        taskService.UpdateTask(updated);
        return Ok(updated);
    }

    [HttpPut("{id}/complete")]
    public IActionResult MarkComplete(int id)
    {
        taskService.MarkTaskAsCompleted(id);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        taskService.DeleteTask(id);
        return NoContent();
    }
}
