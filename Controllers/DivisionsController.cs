using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class DivisionsController : Controller
    {

        private DivisionRepository _repository;


        public DivisionsController(DivisionRepository divisionRepository)
        {
            _repository = divisionRepository;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _repository.Get();
            return Ok(data);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var data = _repository.GetById(id);
            if(data == null)
                    return Ok(new { Message = "Data Not Found" });
            return Ok(data);
            

        }

        // POST api/values
        [HttpPost]
        public ActionResult Create(Division division)
        {
            var result = _repository.Create(division);
            if(result == 0)
            {
                return Ok(new { Message = "Failed Create New Data" });
            }
            return Ok(new { Message = "Success Create New Data" });
        }

      

        // PUT api/values/5
        [HttpPut("{Id}")]
        public ActionResult Update(Division division)
        {
            var result = _repository.Update(division);
            if (result == 0)
            {
                return Ok(new { Message = "Failed Update Data" });
            }
            return Ok(new { Message = "Success Update Data" });
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _repository.Delete(id);
            if(result == 0)
            {
                return Ok(new { Message = "Failed Delete Data" });

            }
            return Ok(new { Message = "Deleted Data Sucessful" });
        }

    }
}

