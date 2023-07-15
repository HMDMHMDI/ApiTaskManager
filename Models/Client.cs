using System.ComponentModel.DataAnnotations;
using ApiTaskManager.Models;

public class Client
{
    public int Id { get; set; }
    public int UnCompletedTask { get; set; } = 0;
    public int CompletedTask { get; set; } = 0;
    // navigation properties .
    public int UserId { get; set; }
    public User User { get; set; }
    public int AdminsId { get; set; }
    public ICollection<Admin> Admins { get; set; }
    public int OwnerId { get; set; }
    public Owner Owner { get; set; }
    public int TasksId { get; set; }
    public ICollection<Task> Tasks { get; set; }
}