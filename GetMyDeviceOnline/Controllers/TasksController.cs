﻿////using GetMyDeviceOnline.DAL;
////using GetMyDeviceOnline.Utils;
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Security.Claims;
////using System.Threading.Tasks;
////using System.Web;
////using System.Web.Mvc;

////namespace GetMyDeviceOnline.Controllers
////{
////    public class TasksController : Controller
////    {
////        [HttpGet]
////        [Authorize]
////        public async Task<ActionResult> Index()
////        {
////            try
////            {
////                // Get All Tasks User Can View
////                ClaimsIdentity userClaimsId = ClaimsPrincipal.Current.Identity as ClaimsIdentity;
////                List<string> userGroupsAndId = await ClaimHelper.GetGroups(userClaimsId);
////                string userObjectId = userClaimsId.FindFirst(Globals.ObjectIdClaimType).Value;
////                userGroupsAndId.Add(userObjectId);
////                ViewData["tasks"] = TasksDbHelper.GetAllTasks(userGroupsAndId);
////                ViewData["userId"] = userObjectId;
////                return View();
////            }
////            catch (Exception e)
////            {
////                // Catch Both ADAL Exceptions and Web Exceptions
////                return RedirectToAction("ShowError", "Error", new { errorMessage = e.Message });
////            }
////        }

////        [HttpPost]
////        [Authorize]
////        public ActionResult TaskSubmit(FormCollection formCollection)
////        {
////            // Create a new task
////            if (formCollection["newTask"] != null && formCollection["newTask"].Length != 0)
////            {
////                TasksDbHelper.AddTask(formCollection["newTask"],
////                    ClaimsPrincipal.Current.FindFirst(Globals.ObjectIdClaimType).Value,
////                    ClaimsPrincipal.Current.FindFirst(Globals.GivennameClaimType).Value + ' '
////                    + ClaimsPrincipal.Current.FindFirst(Globals.SurnameClaimType).Value);
////            }

////            // Change status of existing task
////            if (formCollection["updateTasks"] != null)
////            {
////                foreach (string key in formCollection.Keys)
////                {
////                    if (key.StartsWith("task-id:"))
////                        TasksDbHelper.UpdateTask(Convert.ToInt32(key.Substring(key.IndexOf(':') + 1)), formCollection[key]);
////                }
////            }

////            // Delete a Task
////            if (formCollection["delete"] != null && formCollection["delete"].Length > 0)
////                TasksDbHelper.DeleteTask(Convert.ToInt32(formCollection["delete"]));

////            return RedirectToAction("Index", "Tasks");
////        }

////        [HttpGet]
////        [Authorize]
////        public async Task<ActionResult> Share(string id)
////        {
////            // Values Needed for the People Picker
////            ViewData["tenant"] = ConfigHelper.Tenant;
////            ViewData["token"] = await GraphHelper.AcquireToken(ClaimsPrincipal.Current.FindFirst(Globals.ObjectIdClaimType).Value);

////            // Get the task details
////            GetMyDeviceOnline.Models.Task task = TasksDbHelper.GetTask(Convert.ToInt32(id));
////            if (task == null)
////                RedirectToAction("ShowError", "Error", new { message = "Task Not Found in DB." });
////            ViewData["shares"] = task.SharedWith.ToList();
////            ViewData["taskText"] = task.TaskText;
////            ViewData["taskId"] = task.TaskID;
////            ViewData["userId"] = ClaimsPrincipal.Current.FindFirst(Globals.ObjectIdClaimType).Value;
////            return View();
////        }

////        [HttpPost]
////        [Authorize]
////        public ActionResult Share(int taskId, string objectId, string displayName, string delete, string shareTasks)
////        {
////            // If the share button was clicked, share the task with the user or group
////            if (shareTasks != null && objectId != null && objectId != string.Empty && displayName != null && displayName != string.Empty)
////                TasksDbHelper.AddShare(taskId, objectId, displayName);

////            // If a delete button was clicked, remove the share from the task
////            if (delete != null && delete.Length > 0)
////                TasksDbHelper.DeleteShare(taskId, delete);

////            return RedirectToAction("Share", new { id = taskId });
////        }
////    }
////}