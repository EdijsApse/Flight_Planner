using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Data;

namespace Flight_Planner.Services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity
    {
        public EntityService(IFlightPlannerDBContext context) : base(context) {}

        public void Create(T entity)
        {
            Create<T>(entity);
        }

        public void Delete(T entity)
        {
            Delete<T>(entity);
        }

        public T GetById(int id)
        {
            return GetById<T>(id);
        }

        public IEnumerable<T> Get()
        {
            return Get<T>();
        }

        public IQueryable<T> Query()
        {
            return Query<T>();
        }

        public IQueryable<T> QueryById(int id)
        {
            return QueryById<T>(id);
        }

        public void Update(T entity)
        {
            Update<T>(entity);
        }

        public void RemoveAll()
        {
            RemoveAll<T>();
        }
    }
}
