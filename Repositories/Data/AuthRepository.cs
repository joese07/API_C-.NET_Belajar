using System;
using API.Context;
using API.Handler;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories.Data
{
    public class AuthRepository
    {
        private MyContext myContext;

        public AuthRepository(MyContext context)
        {
            myContext = context;
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
                            return resultUser;

                    }

                    return result;

                }
                return 0;
               
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
                   

                    var result = data.Employee.FullName;
             
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

                return 0 ;

            }
            catch 
            {
                return 0;
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


              
                return 0;
            }

          
            return 0;
        }

    }
}

