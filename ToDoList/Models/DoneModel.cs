namespace ToDoList
{
    public class DoneModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";

        public string Content { get; set; } = "";
        public DateTime ToDoDate { get; set; }

        public DateTime DoneTime { get; set; }
        public string IP { get; set; } = "unknown";

    }
}
