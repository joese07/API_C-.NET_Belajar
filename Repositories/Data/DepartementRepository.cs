using System;
using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data
{

    public class DepartementRepository : GeneralRepository<Departement>
    {
        private MyContext myContext;

        public DepartementRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
    //public class DepartementRepository : IRepository<Departement, int>
    //{
    //    private MyContext myContext;

    //    public DepartementRepository(MyContext context)
    //    {
    //        myContext = context;
    //    }

  
    //    public int Create(Departement departement)
    //    {
    //        myContext.Departements.Add(departement);
    //        var result = myContext.SaveChanges();
    //        return result;
    //    }

    //    public int Delete(int id)
    //    {
    //        var data = myContext.Departements.Find(id);
    //        if(data != null)
    //        {
    //            myContext.Remove(data);
    //            var result = myContext.SaveChanges();
    //            return result;
    //        }

    //        return 0;
    //    }

    //    public IEnumerable<Departement> Get()
    //    {
    //        return myContext.Departements.ToList();
    //    }

    //    public Departement GetById(int id)
    //    {
    //        return myContext.Departements.Find(id);
    //    }

    //    public int Update(Departement departement)
    //    {
    //        myContext.Entry(departement).State = Microsoft.EntityFrameworkCore.
    //            EntityState.Modified;
    //        var result = myContext.SaveChanges();
    //        return result;
    //    }
    //}
}

