using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiTaskManager.Models;
using Microsoft.AspNetCore.Identity;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? EmailAddress { get; set; }
    // navigation properties .
    public int AdminId { get; set; }
    public Admin Admin { get; set; }
    public int OwnerId { get; set; }
    public Owner Owner { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
}