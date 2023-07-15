using System.ComponentModel.DataAnnotations;
using ApiTaskManager.Models;
public class Task
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime EndTime { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    
    // navigation properties .
    public int ClientsId { get; set; }
    public ICollection<Client> Clients { get; set; }
    public int AdminsId { get; set; }
    public ICollection<Admin> Admins { get; set; }
    public int OwnerId { get; set; }
    public Owner Owner { get; set; }
}