using ApiTaskManager.Models;
public class AdminTask
{
    public int AdminsId { get; set; }    
    public Admin Admin { get; set; }
    public int TasksId { get; set; }
    public Task Task { get; set; }
}