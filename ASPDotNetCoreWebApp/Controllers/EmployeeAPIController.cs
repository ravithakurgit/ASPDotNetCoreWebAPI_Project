using ASPDotNetCoreWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPDotNetCoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly EmployeeDbContext employeeDbContext;

        public EmployeeAPIController(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetStudents()
        {
            var data = await employeeDbContext.Employees.ToListAsync();
            return Ok(data);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var emp = await employeeDbContext.Employees.FindAsync(id);
            if (emp == null) {
                return NotFound();
            }
            return emp;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee employee)
        {
            //await employeeDbContext.Employees.AddAsync(employee);
            //await employeeDbContext.SaveChangesAsync();
            //return Ok(employee);

            employeeDbContext.Employees.Add(employee);
            await employeeDbContext.SaveChangesAsync();

            return Ok(employee);
        }


        //update method to upadate employees
        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            employeeDbContext.Entry(employee).State = EntityState.Modified;

            await employeeDbContext.SaveChangesAsync();
            return Ok(employee);
        }

        //delete method
        [HttpDelete]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var emp = await employeeDbContext.Employees.FindAsync(id);
            if (emp == null)
            {
                return NotFound(id);
            }
            employeeDbContext.Employees.Remove(emp);
            await employeeDbContext.SaveChangesAsync();
            return Ok();
        }

    }
}

