using TodoApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace TodoApi.Services
{
    public class TaskService
    {
        private readonly ITaskRepository repository;
        // private int nextId = 1;

        public TaskService(ITaskRepository repository) => this.repository = repository;

        public void AddTask(string title, string description, DateTime dueDate, string priority)
        {
            var task = new TaskItem
            {
                // Id = nextId++,
                Title = title,
                Description = description,
                DueDate = dueDate,
                Priority = priority,
                IsCompleted = false
            };
            repository.Add(task);
        }

        public void UpdateTask(TaskItem updatedTask) => repository.Update(updatedTask);
        public void DeleteTask(int id) => repository.Delete(id);

        public void MarkTaskAsCompleted(int id)
        {
            var task = repository.GetById(id);
            if (task != null)
            {
                task.MarkAsCompleted();
                repository.Update(task);
            }
        }

        public List<TaskItem> GetTasks(bool? completed = null)
        {
            var all = repository.GetAll();
            return completed == null ? all : all.Where(t => t.IsCompleted == completed).ToList();
        }
    }
}
