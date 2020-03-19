namespace backEnd_taskApi.Models
{
    public class Task
    {
        public int TaskId { get; set; }

        public string Title { get; set; }

        public string  Description { get; set; }

        public string  DataCreate { get; set; }
    
        public string DataAter { get; set; }

        public string DataDrop { get; set; }
    }
}