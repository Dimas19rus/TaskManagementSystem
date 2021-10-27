using System.Collections.Generic;
using System.Linq;
using Domain.Models;

namespace Core.Interfaces
{
    public interface IMainTaskService
    {
        
        MainTask GetTask(int id);
        IQueryable<MainTask> GetTasks();
        IQueryable<MainTask> GetSubTasks(int id);
        IQueryable<MainTask> GetAllSubTasks(int id);
        void AddTask(MainTask item);
        void UpdateTask(MainTask item);
        void RemoveTask(int id);
        void Save();
    }
}