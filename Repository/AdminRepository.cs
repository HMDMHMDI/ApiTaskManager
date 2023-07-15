using ApiTaskManager.Data;
using ApiTaskManager.Interfaces;
using ApiTaskManager.Models;

namespace ApiTaskManager.Repository;

public class AdminRepository : IAdminRepository
{
    private readonly ApplicationDbContext _context;

    public AdminRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool DeleteAdmin(Admin admin)
    {
        _context.Remove(admin);
        return Save();
    }

    public bool CreateAdmin(Admin admin)
    {
        _context.Add(admin);
        return Save();
    }

    public bool UpdateAdmin(Admin admin)
    {
        _context.Update(admin);
        return Save();
    }

    public bool AdminExist(int adminId)
    {
        return _context.Admins.Any(e => e.Id == adminId);
    }

    public Admin GetAdmin(int adminId)
    {
        return _context.Admins.Where(e => e.Id == adminId).FirstOrDefault();
    }

    public Admin GetAdmin(string adminName)
    {
        return _context.Admins.Where(e => e.User.Name == adminName).FirstOrDefault();
    }

    public ICollection<Admin> GetAll()
    {
        return _context.Admins.ToList();
    }

    public ICollection<Task> GetTaskByAdmin(int adminId)
    {
        return _context.AdminTasks.Where(e => e.AdminsId == adminId).Select(e => e.Task).ToList();
    }

    public Owner GetOwnerByAdmin(int adminId)
    {
        return _context.Owners.Where(e => e.AdminsId == adminId).FirstOrDefault();
    }

    public ICollection<Client> GetClientsOfOwner(int adminId)
    {
        return _context.Clients.Where(e => e.AdminsId == adminId).ToList();
    }
}