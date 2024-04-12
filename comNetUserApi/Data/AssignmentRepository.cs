using comNetUserApi.Models;

namespace comNetUserApi.Data
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly List<Assignment> _assignments = new List<Assignment>();

        public AssignmentRepository()
        {
        }

        public void AssignTask(Guid userId, Guid assignmentId)
        {
            var foundedAssignment = _assignments.FirstOrDefault(x => x.Id == assignmentId);
            if (foundedAssignment != null) 
            { 
                foundedAssignment.Assignee = userId;
            }
        }

        public void CreateTask(Assignment assignment)
        {
            _assignments.Add(assignment);
        }

        public List<Assignment> UserAssignments(Guid userId)
        {
            return _assignments.Where(x => x.Assignee == userId || x.Tenant == userId).ToList();
        }
    }
}
