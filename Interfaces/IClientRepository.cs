using ApiTaskManager.Models;

namespace ApiTaskManager.Interfaces;

public interface IClientRepository
{
        bool Save();
        bool AddClient(Client client);
        bool DeleteClient(Client client);
        bool UpdateClient(Client client);
        Client GetClient(int clientId);
        Client GetClient(string clientName);
        ICollection<Client> GetAll();
        // Get Admin From Client
        ICollection<Admin> GetAdminsByClient(int clientId);
        // Get Owner From Client
        Owner GetOwnerByClient(int clientId);
        // Get Tasks From Client
        ICollection<Task> GetTasksByClient(int clientId);
    
}