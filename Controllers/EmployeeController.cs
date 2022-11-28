using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;
using API.Repositories.Data;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {

        private EmployeeRepository _repository;

        public EmployeeController(EmployeeRepository employeeRepository, IConfiguration config, MyContext context)
        {
            _repository = employeeRepository;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var data = _repository.Get();
                if (data == null)
                {
                    return Ok(new
                    {
                        Message = "Data Not Found"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Load Successful",
                        Data = data
                    });
                }


            }
            catch
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Something Wrong..."
                });
            }
        }

            // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
                try
                {
                    var data = _repository.GetById(id);
                    if (data == null)
                        return Ok(new { Message = "Data Not Found" });
                    return Ok(data);
                }
                catch
                {
                    return BadRequest(new
                    {
                        StatusCode = 400,
                        Message = "Something Wrong..."
                    });
                }
         }


        // PUT api/values/5
        [HttpPut("{Id}")]
        public ActionResult Update(Employee employee)
        {
            try
            {
                var result = _repository.Update(employee);
                if (result == 0)
                {
                    return Ok(new { Message = "Failed Update Data" });
                }
                return Ok(new { Message = "Success Update Data" });
            }
            catch
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Something Wrong..."
                });
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = _repository.Delete(id);
                if (result == 0)
                {
                    return Ok(new { Message = "Failed Delete Data" });

                }
                return Ok(new { Message = "Deleted Data Sucessful" });
            }
            catch
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Something Wrong..."
                });

            }

        }
    }
}

