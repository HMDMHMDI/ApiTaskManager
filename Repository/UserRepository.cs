using ApiTaskManager.Data;
using ApiTaskManager.Interfaces;

namespace ApiTaskManager.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool Add(User user)
    {
        _context.Users.Add(user);
        return Save();
    }

    public bool Update(User user)
    {
        _context.Update(user);
        return Save();
    }

    public bool Delete(User user)
    {
        _context.Remove(user);
        return Save();
    }

    public bool UserExist(int userId)
    {
        return _context.Users.Any(e => e.Id == userId);
    }

    public ICollection<User> GetUsers()
    {
        return _context.Users.ToList();
    }

    public User GetUser(int id)
    {
        return _context.Users.Find(id);
    }
}