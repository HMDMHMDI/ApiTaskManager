using ApiTaskManager.Data;
using ApiTaskManager.Interfaces;
using ApiTaskManager.Models;

namespace ApiTaskManager.Repository;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;

    public ClientRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool AddClient(Client client)
    {
        _context.Add(client);
        return Save();
    }

    public bool DeleteClient(Client client)
    {
        _context.Remove(client);
        return Save();
    }

    public bool UpdateClient(Client client)
    {
        _context.Update(client);
        return Save();
    }

    public bool ClientExist(int clientId)
    {
        return _context.Clients.Any(e => e.Id == clientId);
    }

    public Client GetClient(int clientId)
    {
        return _context.Clients.Where(e => e.Id == clientId).FirstOrDefault();
    }

    public Client GetClient(string clientName)
    {
        return _context.Clients.Where(e => e.User.Name == clientName).FirstOrDefault();
    }

    public ICollection<Client> GetAll()
    {
        return _context.Clients.ToList();
    }

    public ICollection<Admin> GetAdminsByClient(int clientId)
    {
        return _context.Admins.Where(e => e.ClientsId == clientId).ToList();
    }

    public Owner GetOwnerByClient(int clientId)
    {
        return _context.Owners.Where(e => e.ClientsId == clientId).FirstOrDefault();
    }

    public ICollection<Task> GetTasksByClient(int clientId)
    {
        return _context.Tasks.Where(e => e.ClientsId == clientId).ToList();
    }
}