using ApiTaskManager.Models;

namespace ApiTaskManager.Interfaces;

public interface IOwnerRepository
{
    bool Save();
    bool CreateOwner(Owner owner);
    bool UpdateOwner(Owner owner);
    bool DeleteOwner(Owner owner);
    bool OwnerExist(int ownerId);
    ICollection<Task> GetTasksOfOwner(int ownerId);
    ICollection<Owner> GetAll();
    Owner GetOwner(string Coname);
    Owner GetOwner(int id);
    //Get Task From Owner
    ICollection<Task> GetTasksByOwner(int ownerId);
    //Get Admin From Owner
    ICollection<Admin> GetAdminsByOwner(int ownerId);
    //Get Client From Owner
    ICollection<Client> GetClientsByOwner(int ownerId);
}