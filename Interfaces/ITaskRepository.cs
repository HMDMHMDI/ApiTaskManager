using ApiTaskManager.Models;

namespace ApiTaskManager.Interfaces;

public interface ITaskRepository
{
    bool Save();
    bool CreateTask(Task task);
    bool UpdateTask(Task task);
    bool DeleteTask(Task task);
    bool TaskExist(int taskId);
    ICollection<Task> GetAll();
    Task GetTask(int taskId);
    Task GetTask(string taskName);
    //Get Clients From Task
    ICollection<Client> GetClientsByTask(int taskId);
    //Get Admins Of Task
    ICollection<Admin> GetAdminByTask(int taskId);
    //Get Owner Of Task
    Owner GetOwnerByTask(int taskId);
}