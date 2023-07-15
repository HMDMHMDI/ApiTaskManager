using System.ComponentModel.DataAnnotations;

namespace ApiTaskManager.Models;
public class Admin
{
    public int Id { get; set; }
    // navigation properties
    public int OwnerId { get; set; }
    public Owner Owner { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int ClientsId { get; set; }
    public ICollection<Client> Clients { get; set; }
    public int TasksId { get; set; }
    public ICollection<Task> Tasks { get;set; }
}