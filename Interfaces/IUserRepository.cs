namespace ApiTaskManager.Interfaces;

public interface IUserRepository
{
    bool Save();
    bool Add(User user);
    bool Update(User user);
    bool Delete(User user);
    bool UserExist(int userId);
    ICollection<User> GetUsers();
    User GetUser(int id);

}