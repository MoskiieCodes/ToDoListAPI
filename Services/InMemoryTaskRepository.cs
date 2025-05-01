using TodoApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace TodoApi.Services
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<TaskItem> tasks = new();

        public void Add(TaskItem task) => tasks.Add(task);
        public void Update(TaskItem updatedTask)
        {
            var index = tasks.FindIndex(t => t.Id == updatedTask.Id);
            if (index >= 0) tasks[index] = updatedTask;
        }

        public void Delete(int id) => tasks.RemoveAll(t => t.Id == id);
        public TaskItem? GetById(int id) => tasks.FirstOrDefault(t => t.Id == id);
        public List<TaskItem> GetAll() => tasks;
    }
}
