namespace TaskManagerApp.Models
{
    public class TaskItem
    {
        public int Id { get; set; }           // EF Core auto-makes this the Primary Key
        
        public string? Title { get; set; }     // Task name
        
        public string? Description { get; set; } // Task details
        
        public bool IsCompleted { get; set; } // done or not
        
        public DateTime CreatedAt { get; set; } = DateTime.Now; // auto-set on creation
    }
}