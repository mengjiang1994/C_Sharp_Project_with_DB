using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFDemo1.Model;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFDemo1.Controllers
{
    [Route("api/Course")]
    public class CourseController : Controller
    {
        private ILMSDataStore _dbstore;

        public CourseController(ILMSDataStore dbstore){
            _dbstore = dbstore;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbstore.GetAllCourses());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult result;
            var course = _dbstore.GetCourse(id);
            if(course != null){
                result = Ok(course);
            } else {
                result = NotFound();
            }
            return result;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Course course)
        {
            var newCourse = Course.CreateCourseFrombody(course);
            _dbstore.AddCourse(newCourse);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Course course)
        {
            _dbstore.EditCourse(id, course);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dbstore.DeleteCourse(id);
        }
    }
}
