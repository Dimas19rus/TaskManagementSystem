using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;
using Domain.Models;

namespace Data.Repositories
{
    public class MainTaskRepository : IRepository<MainTask>
    {
        private readonly AppDBContext _appDbContext;

        public MainTaskRepository(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IQueryable<MainTask> GetAll() => _appDbContext.Tasks;


        public void Add(MainTask item)
        {
            _appDbContext.Tasks.Add(item);
        }

        public void Update(MainTask item)
        {
            _appDbContext.Tasks.Update(item);
        }

        public void Remove(int id)
        {
            _appDbContext.Tasks.Remove(GetAll().First(i => i.ID == id));
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}