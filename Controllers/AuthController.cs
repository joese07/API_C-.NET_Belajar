using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private AuthRepository _repository;
       
        public AuthController(AuthRepository authRepository)
        {
            _repository = authRepository;
        }

        // POST api/values
        [HttpPost("register")]
        public ActionResult Register(string fullName, string email, string birthDate, string password, string retypePassword)
        {
            try
            {
                var result = _repository.Register(fullName, email, birthDate, password, retypePassword);
                if(result == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Register Failed"
                    });
                }
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Register Successful"
                });
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
        [HttpPost("Login")]
        public ActionResult Login(string email, string password)
        {
            try
            {
                ResponseLogin responseLogin = new ResponseLogin();
               
                var result = _repository.Login(email, password);
                if(result == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Login Failed",
                       

                    });
                }

                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Login Successful",
                    Data = new
                    {
                        Id = Convert.ToInt32(result[0]),
                        FullName = result[1],
                        Email = result[2],
                        Role = result[3]
                    }
                });
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
        [HttpPost("ResetPassword")]
        public ActionResult ResetPassword(int id, string password, string retypePassword)
        {
            try
            {
                var result = _repository.NewPassword(id, password, retypePassword);
                if(result == 0)
                {
                    return Ok(new { Message = "Reset Password Failed" });

                }
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Reset Password Successful"
                });
            } catch
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Something Wrong..."
                });
            }
        }

        [HttpPut("ChangePassword")]
        public ActionResult ChangePassword(int id, string oldPassword, string retypePassword, string password)
        {
            try
            {
                var result = _repository.ChangePassword(id, oldPassword, retypePassword, password);
                if(result == 0)
                {
                    return Ok(new { Message = "Change Password Failed" });
                }
                return Ok(new {
                    StatusCode = 200,
                    Message = "Success Change Password" });
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

