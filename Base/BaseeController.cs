using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Base
{
    [Route("api/[controller]")]
    public class BaseeController<Repository, Entity> : Controller
         where Repository : class, IRepository<Entity, int>
        where Entity : class
    {

        Repository repository;

        public BaseeController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var data = repository.Get();
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

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var data = repository.GetById(id);
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

        [HttpPost]
        public ActionResult Create(Entity entity)
        {
            try
            {
                var result = repository.Create(entity);
                if (result == 0)
                {
                    return Ok(new { Message = "Failed Create New Data" });
                }
                return Ok(new { Message = "Success Create New Data" });
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


        [HttpPut("{Id}")]
        public ActionResult Update(Entity entity)
        {
            try
            {
                var result = repository.Update(entity);
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


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = repository.Delete(id);
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

