using ApiTaskManager.Models;
public class AdminClient
{
    public int AdminsId { get; set; }
    public Admin Admin { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
}