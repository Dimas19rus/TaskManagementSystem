using System.Collections.Generic;
using System.Linq;
using API.ApiModels;
using Domain.Models;

namespace API.ViewModels
{
    public class HomeViewModel
    {
        public List<MainTask> Tasks { get; set; }

        public List<MainTask> SubTasks { get; set; }

        public List<MainTask> CompleadTasks { get; set; } = new List<MainTask>();

        public MainTask SelectedTask { get; set; }

        public NewMainTask NewTask { get; set; }

    }
}
