using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace API.ApiModels
{
    public class NewMainTask
    {
        
        public int ID { get; set; }


        [Required(ErrorMessage = "Error null")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Error null")]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "Error null")]
        public string Performers { get; set; } = "";

        
        public DateTime DateRegistration { get; set; }

        [Required(ErrorMessage = "Error null")]
        public int NumberStatus { get; set; } = -1;

        public int OldNumberStatus { get; set; } = -1;

        [Required(ErrorMessage = "Error null")]
        public DateTime Deadline { get; set; }

       
        public int ParentId { get; set; }

        
        public int PlannedLaborIntensity { get; set; }

        public int PlannedLaborIntensitySumMainAndSubTasks =>
            AllSubTasks.Sum(t => t.PlannedLaborIntensity) + PlannedLaborIntensity;

        public int FactualLaborIntensity { get; set; }

        
        public MainTask Parent { get; set; }
        public SelectListItem SelectParent { get; set; }
        public NewMainTask(MainTask task)
        {
            ID = task.ID;
            Name = task.Name;
            Description = task.Description;
            Performers = task.Performers;
            DateRegistration = task.DateRegistration;
            NumberStatus = task.NumberStatus;
            Deadline = task.Deadline;
            ParentId = task.ParentId ?? default(int);
            PlannedLaborIntensity = task.PlannedLaborIntensity;
            FactualLaborIntensity = task.FactualLaborIntensity;
            
            
        }

        public NewMainTask(){}

        public MainTask GetMainTask()
        {
            return new MainTask
            { ID = this.ID,
                Name = this.Name,
                Description = this.Description,
                Performers = this.Performers,
                DateRegistration = this.DateRegistration,
                NumberStatus = this.NumberStatus,
                Deadline = this.Deadline,
                ParentId =  this.ParentId,
                PlannedLaborIntensity = this.PlannedLaborIntensity,
                FactualLaborIntensity = this.FactualLaborIntensity,
                
            };
        }

        public List<SelectListItem> Tasks { get; set; } = new List<SelectListItem>();

        public List<MainTask> AllSubTasks { get; set; } = new List<MainTask>();
    }
}