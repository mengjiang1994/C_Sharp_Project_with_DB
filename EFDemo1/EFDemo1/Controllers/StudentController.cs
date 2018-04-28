using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFDemo1.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFDemo1.Controllers
{
    [Route("api/Student")]
    public class StudentController : Controller
    {
        private ILMSDataStore _dbstore;

        public StudentController(ILMSDataStore dbstore)
        {
            _dbstore = dbstore;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbstore.GetAllStudent());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult result;
            var student = _dbstore.GetStudent(id);
            if (student != null)
            {
                result = Ok(student);
            }
            else
            {
                result = NotFound();
            }
            return result;
        }

        // POST api/values
        public IActionResult Post([FromBody] Student student)
        {
            var newStudent = Student.CreateStudentFrombody(student);
            _dbstore.AddStudent(newStudent);
            return Ok();
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
