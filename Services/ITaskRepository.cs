using TodoApi.Models;
using System.Collections.Generic;

namespace TodoApi.Services
{
    public interface ITaskRepository
    {
        void Add(TaskItem task);
        void Update(TaskItem task);
        void Delete(int id);
        TaskItem? GetById(int id);
        List<TaskItem> GetAll();
    }
}
