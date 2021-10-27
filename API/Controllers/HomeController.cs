using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.ApiModels;
using API.ViewModels;
using Core.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace API.Controllers
{
    public class HomeController : Controller
    {
        private IMainTaskService _mainTaskService;
        private IStringLocalizer<HomeController> _localizer;
        private HomeViewModel _homeViewModel;

        public HomeController(IMainTaskService service, IStringLocalizer<HomeController> localizer)
        {
            _mainTaskService = service;
            _localizer = localizer;
        }


        public IActionResult Index()
        {
            FillViewData();
            _homeViewModel = new HomeViewModel
            {
                Tasks = _mainTaskService.GetTasks().ToList()
            };

            return View(_homeViewModel);
        }

        [HttpPost]
        public ActionResult ParentSearch(int id)
        {
            FillViewData();

            _homeViewModel = new HomeViewModel();
            _homeViewModel.Tasks = _mainTaskService.GetTasks().ToList();
            _homeViewModel.SubTasks = _mainTaskService.GetTasks().Where(a => a.ParentId == id).ToList();
            _homeViewModel.SelectedTask = _mainTaskService.GetTask(id);

            return PartialView(_homeViewModel);
        }

        [Helper.NoDirectAccess]
        public IActionResult CreateAndEdit(int id = 0)
        {
            FillViewData();

            if (id == 0)
            {
                NewMainTask taskNew = new NewMainTask();
                foreach (var item in _mainTaskService.GetTasks().ToList())
                    taskNew.Tasks.Add(new SelectListItem {Text = item.Name, Value = item.ID.ToString()});

                taskNew.OldNumberStatus = taskNew.NumberStatus;
                return View(taskNew);
            }

            NewMainTask task = new NewMainTask(_mainTaskService.GetTask(id));

            if (task == null)
                return NotFound();

            foreach (var item in _mainTaskService.GetTasks().ToList())
                task.Tasks.Add(new SelectListItem {Text = item.Name, Value = item.ID.ToString()});

            task.AllSubTasks = _mainTaskService.GetAllSubTasks(task.ID).ToList();

            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAndEdit(int id,
            [Bind(
                "ID,Name,Description,Performers,DateRegistration,OldNumberStatus,NumberStatus,PlannedLaborIntensity,FactualLaborIntensity,Deadline,ParentId,Parent,Tasks")]
            NewMainTask task)
        {
            FillViewData();

            if (task.PlannedLaborIntensity <= 0)
                ModelState.AddModelError("PlannedLaborIntensity", ViewData["ValidPlannedLaborIntensity"].ToString());

            if (task.NumberStatus == 2) 
                if(task.OldNumberStatus != 1)
                    ModelState.AddModelError("NumberStatus", ViewData["ValidNumberStatus1"].ToString());

            if (task.NumberStatus == 3)
                if (task.OldNumberStatus != 1)
                    ModelState.AddModelError("NumberStatus", ViewData["ValidNumberStatus2"].ToString());
            
            if (task.NumberStatus == 3)
                if (task.AllSubTasks.Any(t => t.NumberStatus != 1))
                    ModelState.AddModelError("NumberStatus", ViewData["ValidNumberStatus3"].ToString());

            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    MainTask maintask = task.GetMainTask();
                    maintask.ID = 0;
                    if (task.ParentId == 0)
                        maintask.ParentId = null;

                    maintask.DateRegistration = DateTime.Now;
                    _mainTaskService.AddTask(maintask);
                    _mainTaskService.Save();
                }
                //Update
                else
                {
                    try
                    {
                        MainTask maintask = task.GetMainTask();
                        maintask.ID = task.ID;
                        if (task.ParentId == 0)
                            maintask.ParentId = null;
                        task.AllSubTasks = _mainTaskService.GetAllSubTasks(task.ID).ToList();
                        if (maintask.NumberStatus==3)
                        {
                            foreach (var item in task.AllSubTasks)
                            {
                                item.NumberStatus = 3;
                                _mainTaskService.UpdateTask(item);
                            }
                        }
                        _mainTaskService.UpdateTask(maintask);
                        _mainTaskService.Save();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TaskModelExists(task.ID))
                            return NotFound();
                    }
                }

                HomeViewModel model = new HomeViewModel();
                model.Tasks = _mainTaskService.GetTasks().ToList();

                model.SelectedTask = task.GetMainTask();

                model.SubTasks = _mainTaskService.GetSubTasks(task.ID).ToList();


                return Json(new
                {
                    isValid = true,
                    html = Helper.RenderRazorViewToString(this, "Index", model)
                });
            }

            foreach (var item in _mainTaskService.GetTasks().ToList())
                task.Tasks.Add(new SelectListItem {Text = item.Name, Value = item.ID.ToString()});

            task.AllSubTasks = _mainTaskService.GetAllSubTasks(task.ID).ToList();

            return Json(new
                {isValid = false, html = Helper.RenderRazorViewToString(this, "CreateAndEdit", task)});
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            FillViewData();
            _mainTaskService.RemoveTask(id);
            _mainTaskService.Save();
            _homeViewModel = new HomeViewModel();
            _homeViewModel.Tasks = _mainTaskService.GetTasks().ToList();
            _homeViewModel.SubTasks = _mainTaskService.GetTasks().Where(a => a.ParentId == id).ToList();
            _homeViewModel.SelectedTask = _mainTaskService.GetTask(id);
            return Json(new {html = Helper.RenderRazorViewToString(this, "Index", _homeViewModel)});
        }

        public void FillViewData()
        {
            ViewData["SelectedTask"] = _localizer["SelectedTask"];
            ViewData["SubTask"] = _localizer["SubTask"];

            ViewData["DateRegistration"] = _localizer["DateRegistration"];
            ViewData["Deadline"] = _localizer["Deadline"];
            ViewData["FactualLaborIntensity"] = _localizer["FactualLaborIntensity"];
            ViewData["Performers"] = _localizer["Performers"];
            ViewData["PlannedLaborIntensity"] = _localizer["PlannedLaborIntensity"];
            ViewData["PlannedLaborIntensitySumMainAndSubTasks"] = _localizer["PlannedLaborIntensitySumMainAndSubTasks"];

            ViewData["Status"] = _localizer["Status"];
            ViewData["Appointed"] = _localizer["Appointed"];
            ViewData["Performed"] = _localizer["Performed"];
            ViewData["Suspended"] = _localizer["Suspended"];
            ViewData["Completed"] = _localizer["Completed"];

            ViewData["Name"] = _localizer["Name"];
            ViewData["Description"] = _localizer["Description"];

            ViewData["AddSubTask"] = _localizer["AddSubTask"];
            ViewData["Edit"] = _localizer["Edit"];
            ViewData["Delete"] = _localizer["Delete"];
            ViewData["Parent"] = _localizer["Parent"];

            ViewData["Update task"] = _localizer["Update task"];
            ViewData["New task"] = _localizer["New task"];
            ViewData["Apply"] = _localizer["Apply"];
            ViewData["ErrorNull"] = _localizer["ErrorNull"];
            ViewData["ValidPlannedLaborIntensity"] = _localizer["ValidPlannedLaborIntensity"];
        }

        private bool TaskModelExists(int id) => _mainTaskService.GetTasks().Any(e => e.ID == id);
    }
}