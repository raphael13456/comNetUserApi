using comNetUserApi.Models;

namespace comNetUserApi.Data
{
    public interface IAssignmentRepository
    {
        public void AssignTask(Guid userId, Guid assignmentId);
        public void CreateTask(Assignment assignment);
        public List<Assignment> UserAssignments(Guid userId);
    }
}
