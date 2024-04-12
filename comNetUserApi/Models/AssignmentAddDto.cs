namespace comNetUserApi.Models
{
    public class AssignmentAddDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tenant { get; set; }
        public string Assignee { get; set; }
        public DateTime DueDate { get; set; }
    }
}
