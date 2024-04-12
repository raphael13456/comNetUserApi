using comNetUserApi.Data;
using comNetUserApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace comNetUserApi.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentsController(IAssignmentRepository assignmentRepository) 
        { 
            _assignmentRepository = assignmentRepository;
        }

        [HttpPost]
        public IActionResult AddTask([FromBody] AssignmentAddDto dto)
        {
            var hasAssignee = Guid.TryParse(dto.Assignee, out var assigneId);
            var hasTenant = Guid.TryParse(dto.Tenant, out var tenant);

            if (!hasAssignee || !hasTenant) 
            {
                return BadRequest("You have to provide an assignee and a tenant!");
            }

            var task = new Assignment()
            {
                Assignee = assigneId,
                Description = dto.Description,
                DueDate = dto.DueDate,
                Tenant = tenant,
                Title = dto.Title,
                CreatedDate = DateTime.Now,
            };

            _assignmentRepository.CreateTask(task);
            return Ok(task);
        }

        [HttpGet]
        public IActionResult GetTaskForUser(string userId)
        {
            var validUserID = Guid.TryParse(userId, out var id);
            if (!validUserID)
            {
                return BadRequest("The provided Id is invalid");
            }

            var result = _assignmentRepository.UserAssignments(id);
            if (result == null || result?.Count == 0) 
            { 
                return NotFound($"User {userId} has not been found");
            }
            return Ok(result);
        }
    }
}
 