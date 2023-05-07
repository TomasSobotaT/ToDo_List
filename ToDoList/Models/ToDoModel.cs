namespace ToDoList
{
    
    public class ToDoModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";

        public string Content { get; set; } = "";
        public DateTime ToDoDate { get; set; } = DateTime.Now;

        public string IP { get; set; } = "unknown";
    }
}
