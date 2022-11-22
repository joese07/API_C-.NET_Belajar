using System;
using API.Context;
using API.Models;

namespace API.Repositories.Data
{
	public class EmployeeRepository
	{
		private MyContext myContext;

		public EmployeeRepository(MyContext context)
		{
			myContext = context;
		}

		public int Delete(int id)
		{
			var data = myContext.Employees.Find(id);
			if(data != null)
			{
				myContext.Remove(data);
				var result = myContext.SaveChanges();
				return result;
			}

			return 0;
		}

		public IEnumerable<Employee> Get()
		{
			return myContext.Employees.ToList();
		}

		public Employee GetById(int id)
		{
			return myContext.Employees.Find(id);
		}

		public int Update(Employee employee)
        {
            myContext.Set<Employee>().Update(employee);
            var result = myContext.SaveChanges();
            return result;
        }
	}
}

