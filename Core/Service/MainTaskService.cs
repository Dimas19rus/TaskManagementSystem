using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Core.Interfaces;
using Data;
using Data.Interfaces;
using Domain.Models;

namespace Core.Repository
{
    public class MainTaskService : IMainTaskService
    {
        private readonly IRepository<MainTask> _repository;

        public MainTaskService(IRepository<MainTask> repository)
        {
            _repository = repository;
        }

        public MainTask GetTask(int id)
        {
            if (GetTasks().Any(i => i.ID == id))
            {
                return GetTasks().First(i => i.ID == id);
            }
            return new MainTask();
        } 

        public IQueryable<MainTask> GetTasks() => _repository.GetAll();

        public IQueryable<MainTask> GetSubTasks(int id) => GetTasks().Where(i => i.ParentId == id);
        public IQueryable<MainTask> GetAllSubTasks(int id)
        {
            IQueryable<MainTask> subTasks = GetSubTasks(id);
             
            foreach (var task in subTasks)
            {
                subTasks = subTasks.Union(GetAllSubTasks(task.ID));
            }
            
            return subTasks;
        }

        //private IQueryable<MainTask> GetTreeRootsTask(int id)
        //{
        //    IQueryable<MainTask> subTasks = GetSubTasks(id);
        //    IQueryable<MainTask> subSubTasks=null;
        //    foreach (var task in subTasks)
        //    {
        //        subSubTasks = GetSubTasks(task.ID);
        //        IQueryable<MainTask> tasks = null;
        //        if (subTasks.Any(t=>t.ParentId==task.ID))
        //        {
        //             tasks = GetTreeRootsTask(task.ID);
        //        }
        //        if(tasks!=null)
        //            subSubTasks = subSubTasks.Union(tasks);
                
        //    }
        //    if (subSubTasks != null)
        //        subTasks = subTasks.Union(subSubTasks);
        //    return subTasks;
        //}

        public void AddTask(MainTask item) => _repository.Add(item);

        public void UpdateTask(MainTask item) => _repository.Update(item);

        public void RemoveTask(int id) => _repository.Remove(id);
        public void Save() => _repository.Save();

        public void RemoveTask(MainTask task) => _repository.Remove(task.ID);
    }
}