using ApiTaskManager.Models;

namespace ApiTaskManager.Interfaces;

public interface IOwnerRepository
{
    bool Save();
    bool CreateOwner(Owner owner);
    bool UpdateOwner(Owner owner);
    bool DeleteOwner(Owner owner);
    bool OwnerExist(int ownerId);
    int GetTasksOfOwner(int ownerId);
    ICollection<Owner> GetAll();
    Owner GetOwner(string name);
    Owner GetOwner(int id);
    //Get Task From Owner
    ICollection<Task> GetTasksByOwner(int ownerId);
    ICollection<Task> GetTasksByOwner(string ownerName);
    //Get Admin From Owner
    ICollection<Admin> GetAdminsByOwner(string ownerName);
    ICollection<Admin> GetAdminsByOwner(int adminId);
    //Get Client From Owner
    ICollection<Client> GetClientByOwner(string ownerName);
    ICollection<Client> GetClientByOwner(int clientId);
}