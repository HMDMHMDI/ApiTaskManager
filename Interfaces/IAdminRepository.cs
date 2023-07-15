using ApiTaskManager.Models;

namespace ApiTaskManager.Interfaces;

public interface IAdminRepository
{
    bool Save();
    bool DeleteAdmin(Admin admin);
    bool CreateAdmin(Admin admin);
    bool UpdateAdmin(Admin admin);
    bool AdminExist(int adminId);
    Admin GetAdmin(int adminId);
    Admin GetAdmin(string adminName);
    ICollection<Admin> GetAll();
    // Get Task From Admin
    ICollection<Task> GetTaskByAdmin(int adminId);
    //Get Owner From Admin
    Owner GetOwnerByAdmin(int adminId);
    //Get Clients Of Admin
    ICollection<Client> GetClientsOfOwner(int adminId);
}