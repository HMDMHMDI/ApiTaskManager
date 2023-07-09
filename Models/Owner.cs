using ApiTaskManager.Models;
public class Owner
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    // navigation properties .
    public int UserId { get; set; }
    public User User { get; set; }
    public int AdminsId { get; set; }
    public ICollection<Admin> Admins { get; set; }
    public int ClientsId { get; set; }
    public ICollection<Client> Clients { get; set; }
    public int TasksId { get; set; }
    public ICollection<Task> Tasks { get; set; }
}