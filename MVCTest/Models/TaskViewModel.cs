namespace MVCTest.Models
{
    public class TaskViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public string Creator { get; set; }
        public string Assignee { get; set; }
    }
}
