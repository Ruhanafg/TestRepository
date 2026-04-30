using TaskApp. DAL;
using TaskApp. Model;
using Microsoft.EntityFrameworkCore;
namespace TaskApp.Service
{
    public class TaskService
    {
        public readonly TaskApplicationDbContext instanceTaskApplicationDbContext;

        public TaskService(TaskApplicationDbContext _context)
        {
            instanceTaskApplicationDbContext = _context;
        }

        public List<TaskModel> GetTasksInPage(int pageIndex, int pageSize)
        {
            var tasks = new List<TaskModel>();
            tasks = instanceTaskApplicationDbContext.Tasks.Skip(pageIndex).Take(pageSize).ToList();
            return tasks;
        }

          public async Task<List<TaskModel>> GetTasksAsync()
        {
            return await instanceTaskApplicationDbContext.Tasks.ToListAsync();
        }

    }
}