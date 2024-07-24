using Day2.Models;

namespace Day2.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        ITIContext db;

        public GenericRepository( ITIContext db)
        {
            this.db = db;
        }

        public List<TEntity> selectall()
        {
            return db.Set<TEntity>().ToList();
        }

        public TEntity selectbyid(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public void add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
          
        }

        public void update(TEntity entity)
        {
            db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void delete(int id)
        {
            TEntity obj = db.Set<TEntity>().Find(id);
            db.Set<TEntity>().Remove(obj);
        }

        public void save()
        {
            db.SaveChanges();
        }


    }
}
