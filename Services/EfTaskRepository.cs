using TodoApi.Models;
using TodoApi.Data;
using System.Collections.Generic;
using System.Linq;

namespace TodoApi.Services
{
    public class EfTaskRepository : ITaskRepository
    {
        private readonly TodoDbContext db;

        public EfTaskRepository(TodoDbContext db)
        {
            this.db = db;
        }

        public void Add(TaskItem task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var task = db.Tasks.Find(id);
            if (task != null)
            {
                db.Tasks.Remove(task);
                db.SaveChanges();
            }
        }

        public List<TaskItem> GetAll() => db.Tasks.ToList();

        public TaskItem? GetById(int id) => db.Tasks.Find(id);

        public void Update(TaskItem task)
        {
            db.Tasks.Update(task);
            db.SaveChanges();
        }
    }
}
