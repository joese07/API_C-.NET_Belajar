using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class DepartementController : Controller
    {

        private DepartementRepository _repository;

        public DepartementController(DepartementRepository departementRepository)
        {
            _repository = departementRepository;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var data = _repository.Get();
                if(data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Not Found",
                    });
                } else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Load Successful",
                        Data = data
                    });
                }
            } catch
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
        public ActionResult GetById(int id)
        {
            try
            {
                var data = _repository.GetById(id);
                if (data == null)
                {
                    return Ok(new { Message = "Data Not Found" });
                } else
                {
                    return Ok(new
                    {
                        Message = "Data Load Successful",
                        Data = data
                    });
                }
   
            } catch
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Something Wrong..."
                });
            }
           


        }

        // POST api/values
        [HttpPost]
        public ActionResult Create(Departement  departement)
        {
            try
            {
                var result = _repository.Create(departement);
                if (result == 0)
                {
                    return Ok(new { Message = "Failed Create New Data" });
                }
                return Ok(new { Message = "Success Create New Data" });
            } catch
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
        public ActionResult Update(Departement departement)
        {
            try
            {
                var result = _repository.Update(departement);
                if (result == 0)
                {
                    return Ok(new { Message = "Failed Update Data" });
                }
                return Ok(new { Message = "Success Update Data" });
            } catch
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
            } catch
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

