using ApiTaskManager.Data;
using ApiTaskManager.Interfaces;
using ApiTaskManager.Models;

namespace ApiTaskManager.Repository;

public class OwnerRepository : IOwnerRepository
{
    private readonly ApplicationDbContext _context;

    public OwnerRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool CreateOwner(Owner owner)
    {
        _context.Add(owner);
        return Save();
    }

    public bool UpdateOwner(Owner owner)
    {
        _context.Update(owner);
        return Save();
    }

    public bool DeleteOwner(Owner owner)
    {
        _context.Remove(owner);
        return Save();
    }

    public bool OwnerExist(int ownerId)
    {
        return _context.Owners.Any(o => o.Id == ownerId);
    }

    public ICollection<Task> GetTasksOfOwner(int ownerId)
    {
        return _context.Tasks.Where(e => e.OwnerId == ownerId).ToList();
    }

    public ICollection<Owner> GetAll()
    {
        return _context.Owners.ToList();
    }

    public Owner GetOwner(string coName)
    {
        return _context.Owners.Where(e => e.CompanyName == coName).FirstOrDefault();
    }

    public Owner GetOwner(int id)
    {
        return _context.Owners.Where(e => e.Id == id).FirstOrDefault();
    }

    public ICollection<Task> GetTasksByOwner(int ownerId)
    {
        return _context.Tasks.Where(e => e.OwnerId == ownerId).ToList();
    }

    public ICollection<Admin> GetAdminsByOwner(int ownerId)
    {
        return _context.Admins.Where(e => e.OwnerId == ownerId).ToList();
    }

    public ICollection<Client> GetClientsByOwner(int ownerId)
    {
        return _context.Clients.Where(e => e.OwnerId == ownerId).ToList();
    }
}