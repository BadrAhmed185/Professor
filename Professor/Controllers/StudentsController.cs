using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Professor.Models;

namespace Professor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext context;

        public StudentsController(AppDbContext context)

        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            context.Students.Add(student);
             context.SaveChanges();
            // Logic to create a new student
            return Ok( new { Message = $"Student '{student.Name}' created successfully." });
        }
    }
}
