using ApiTaskManager.Data;
using ApiTaskManager.Interfaces;
using ApiTaskManager.Models;

namespace ApiTaskManager.Repository;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _context;

    public TaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool CreateTask(Task task)
    {
        _context.Add(task);
        return Save();
    }

    public bool UpdateTask(Task task)
    {
        _context.Update(task);
        return Save();
    }

    public bool DeleteTask(Task task)
    {
        _context.Remove(task);
        return Save();
    }

    public bool TaskExist(int taskId)
    {
        return _context.Tasks.Any(e => e.Id == taskId);
    }

    public ICollection<Task> GetAll()
    {
        return _context.Tasks.ToList();
    }

    public Task GetTask(int taskId)
    {
        return _context.Tasks.Where(e => e.Id == taskId).FirstOrDefault();
    }

    public Task GetTask(string titleName)
    {
        return _context.Tasks.Where(e => e.Title == titleName).FirstOrDefault();
    }

    public ICollection<Client> GetClientsByTask(int taskId)
    {
        return _context.Clients.Where(e => e.TasksId == taskId).ToList();
    }

    public ICollection<Admin> GetAdminByTask(int taskId)
    {
        return _context.Admins.Where(e => e.TasksId == taskId).ToList();
    }

    public Owner GetOwnerByTask(int taskId)
    {
        return _context.Owners.Where(e => e.TasksId == taskId).FirstOrDefault();
    }
}