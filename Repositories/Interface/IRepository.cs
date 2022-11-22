using System;
namespace API.Repositories.Interface
{
    public interface IRepository<Entity, Key> where Entity : class
    {
        public IEnumerable<Entity> Get();

        public Entity GetById(Key id);

        public int Create(Entity Entity);

        public int Update(Entity Entity);

        public int Delete(Key id);
    }


    //Generic Repositori
    //public interface IRepository<Entity> where Entity : class
    //{
    //    public List<Entity> Get();

    //    public Entity GetById(int id);

    //    public int Create(Entity Entity);

    //    public int Update(Entity Entity);

    //    public int Delete(int id);
    //}
}

