using System;
using API.Context;
using API.Handler;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Repositories.Data
{
    public class AuthRepository
    {
        private MyContext myContext;
        public IConfiguration _configuration;

        public AuthRepository(MyContext context, IConfiguration config)
        {
            myContext = context;
            _configuration = config;
        }

        public int Register(string fullName, string email, string birthDate, string password, string retypePassword)
        {
            var dataEmail = myContext.Users.Include(x => x.Employee).SingleOrDefault(x => x.Employee.Email.Equals(email));
            if (dataEmail == null)
            {
                if (retypePassword == password)
                {
                    Employee employee = new Employee()
                    {
                        FullName = fullName,
                        Email = email,
                        BirthDate = birthDate
                    };


                    myContext.Employees.Add(employee);
                    var result = myContext.SaveChanges();
                    if (result > 0)
                    {
                        var id = myContext.Employees.SingleOrDefault(x => x.Email.Equals(email)).Id;
                        User user = new User()
                        {
                            Id = id,
                            Password = Hashing.HashPassword(password),
                            RoleId = 2,
                        };

                        myContext.Users.Add(user);
                        var resultUser = myContext.SaveChanges();
                        if (resultUser > 0)
                            return 2;

                    }

                    return 2;

                }
                 return 1;
  
            }
            return 0;
        }

        public string Login(string email, string password)
        {
            var data = myContext.Users
               .Include(x => x.Employee)
               .Include(x => x.Roles)
               .SingleOrDefault(x => x.Employee.Email.Equals(email));

            if (data != null)
            {
                if (Hashing.ValidatePassword(password, data.Password))
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", data.Employee.Id.ToString()),
                        new Claim("DisplayName", data.Employee.FullName),
                        new Claim("Email", data.Employee.Email),
                        new Claim("Roles", data.Roles.Name)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    var result = new JwtSecurityTokenHandler().WriteToken(token);

                    //return Ok(new JwtSecurityTokenHandler().WriteToken(token));

                    //string[] result = new string[4];
                    //result[0] = Convert.ToString(data.Employee.Id);
                    //result[1] = data.Employee.FullName;
                    //result[2] = data.Employee.Email;
                    //result[3] = data.Roles.Name;

                    return result;


                }

                return null;

            }

            return null;
        }


        public int NewPassword(int id, string password, string retypePassword)
        {
            try
            {
                var data = myContext.Users.Find(id);


                if (data != null)
                {
                    if (password == retypePassword)
                    {
                        data.Password = Hashing.HashPassword(password);
                        myContext.Entry(data).State = EntityState.Modified;
                        var result = myContext.SaveChanges();
                        if (result > 0)
                            return result;
                    }
                    return 0;

                }

                return 1 ;

            }
            catch 
            {
                return 1;
            }

        }

        public int ChangePassword(int id, string oldPassword, string retypePassword, string password)
        {
            var data = myContext.Users.Include(x => x.Employee).SingleOrDefault(x => x.Employee.Id.Equals(id));

            if (data != null)
            {

                if (password == retypePassword)
                {
                    if (Hashing.ValidatePassword(oldPassword, data.Password))
                    {
                        data.Password = Hashing.HashPassword(password);
                        myContext.Entry(data).State = EntityState.Modified;
                        var result = myContext.SaveChanges();
                        if (result > 0)
                            return result;
                    }
                  
                    return 0;

                }


              
                return 1;
            }

          
            return 0;
        }

    }
}

