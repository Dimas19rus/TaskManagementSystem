using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Domain.Models
{
    public class MainTask
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Performers { get; set; }
        public DateTime DateRegistration { get; set; }
        public int NumberStatus { get; set; }
        public int PlannedLaborIntensity { get; set; }
        public int FactualLaborIntensity { get; set; }
        public DateTime Deadline { get; set; }
        public int? ParentId { get; set; }
        public MainTask Parent { get; set; }
        
    }
}