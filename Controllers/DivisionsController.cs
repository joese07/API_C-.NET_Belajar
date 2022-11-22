using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
  
    [Route("api/[controller]")]
    //[Authorize(Roles = "Admin")]
    //Menggunakan Metode Generic Controller
    public class DivisionsController : BaseeController<DivisionRepository, Division>
    {
        
        private readonly DivisionRepository _repository;


        public DivisionsController(DivisionRepository divisionRepository) : base(divisionRepository)
        {
            _repository = divisionRepository;
        }




        //Menggunakan Metoda Biasa
        //public class DivisionsController : Controller
        //{

        //    private DivisionRepository _repository;


        //    public DivisionsController(DivisionRepository divisionRepository)
        //    {
        //        _repository = divisionRepository;
        //    }
            // GET: api/values
            //[HttpGet]
            //public ActionResult GetAll()
            //{
            //    try
            //    {
            //        var data = _repository.Get();
            //        if(data == null)
            //        {
            //            return Ok(new
            //            {
            //                Message = "Data Not Found"
            //            });
            //        } else
            //        {
            //            return Ok(new
            //            {
            //                StatusCode = 200,
            //                Message = "Data Load Successful",
            //                Data = data
            //            });
            //        }


            //    } catch
            //    {
            //        return BadRequest(new
            //        {
            //            StatusCode = 400,
            //            Message = "Something Wrong..."
            //        });
            //    }


            //}

            //// GET api/values/5
            //[HttpGet("{id}")]
            //public ActionResult GetById(int id)
            //{
            //    try
            //    {
            //        var data = _repository.GetById(id);
            //        if (data == null)
            //            return Ok(new { Message = "Data Not Found" });
            //        return Ok(data);
            //    } catch
            //    {
            //        return BadRequest(new
            //        {
            //            StatusCode = 400,
            //            Message = "Something Wrong..."
            //        });
            //    }



            //}

            //// POST api/values
            //[HttpPost]
            //public ActionResult Create(Division division)
            //{
            //    try
            //    {
            //        var result = _repository.Create(division);
            //        if (result == 0)
            //        {
            //            return Ok(new { Message = "Failed Create New Data" });
            //        }
            //        return Ok(new { Message = "Success Create New Data" });
            //    }
            //    catch
            //    {
            //        return BadRequest(new
            //        {
            //            StatusCode = 400,
            //            Message = "Something Wrong..."
            //        });
            //    }

            //}



            //// PUT api/values/5
            //[HttpPut("{Id}")]
            //public ActionResult Update(Division division)
            //{
            //    try
            //    {
            //        var result = _repository.Update(division);
            //        if (result == 0)
            //        {
            //            return Ok(new { Message = "Failed Update Data" });
            //        }
            //        return Ok(new { Message = "Success Update Data" });
            //    } catch
            //    {
            //        return BadRequest(new
            //        {
            //            StatusCode = 400,
            //            Message = "Something Wrong..."
            //        });
            //    }

            //}


            //// DELETE api/values/5
            //[HttpDelete("{id}")]
            //public ActionResult Delete(int id)
            //{
            //    try
            //    {
            //        var result = _repository.Delete(id);
            //        if (result == 0)
            //        {
            //            return Ok(new { Message = "Failed Delete Data" });

            //        }
            //        return Ok(new { Message = "Deleted Data Sucessful" });
            //    } catch
            //    {
            //        return BadRequest(new
            //        {
            //            StatusCode = 400,
            //            Message = "Something Wrong..."
            //        });

            //    }

            //}

        }
}

