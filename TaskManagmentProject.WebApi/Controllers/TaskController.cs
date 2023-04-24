using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using TaskManagmentProject.Abstraction.IRepositories;
using TaskManagmentProject.Abstraction.IServices;
using TaskManagmentProject.Common.DTOS;
using TaskManagmentProject.Domain.Models;
using TaskManagmentProject.Service.Service;

namespace TaskManagmentProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITaskService _taskService;
        private readonly ITaskFileService _taskFileService;

        public TaskController(IMapper mapper, ITaskService taskService, ITaskFileService taskFileService)
        {
            _taskService = taskService;
            _taskFileService = taskFileService;
            _mapper = mapper;
        }

        [HttpGet("GetAllTasks")]
        [Authorize(Roles = "View")]
        public ActionResult<IEnumerable<TaskDomainCreateDto>> GetAllTasks()
        {
            var userId = User.Claims.First().Value;
            var tasks = _taskService.Set();
            foreach (var task in tasks)
            {
                task.AttachedFiles = _taskFileService.Set().Where(a => a.TaskId == task.Id).ToList();
            }
            var taskViewModels = _mapper.Map<List<TaskDomainCreateDto>>(tasks);
            return Ok(taskViewModels);
        }

        [HttpGet("TasksAssignedToCurrentUser")]
        [Authorize(Roles = "View")]
        public ActionResult<IEnumerable<TaskDomainCreateDto>> TasksAssignedToCurrentUser()
        {
            var userId = User.Claims.First().Value;
            var tasks = _taskService.Set()
                .Where(a => a.AssignedUserId == Convert.ToInt32(userId));
            foreach (var task in tasks)
            {
                task.AttachedFiles = _taskFileService.Set().Where(a => a.TaskId == task.Id).ToList();
            }
            var taskViewModels = _mapper.Map<List<TaskDomainCreateDto>>(tasks);
            return Ok(taskViewModels);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "View")]
        public ActionResult<TaskDomainCreateDto> GetTaskWithID(int id)
        {
            var userId = User.Claims.First().Value;
            var task = _taskService.Fetch(id);

            if (task == null)
            {
                return NotFound();
            }

            var taskViewModel = _mapper.Map<TaskDomainCreateDto>(task);
            return Ok(taskViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Create")]
        public ActionResult<TaskDomainCreateDto> Post(TaskDomainCreateDto taskViewModel)
        {
            var userId = User.Claims.First().Value;
            var task = _mapper.Map<TaskDomain>(taskViewModel);
            task.CreatedAt = DateTime.Now;
            task.CreatedById = Convert.ToInt32(userId);
            _taskService.Save(task);
            foreach (var file in taskViewModel.AttachedFiles)
            {
                _taskFileService.Save(new TaskFile { TaskId = task.Id, FileName = file.FileName, FileContent = file.FileContent });
            }
            var createdTaskViewModel = _mapper.Map<TaskUpdateDto>(task);
            return CreatedAtAction(nameof(GetTaskWithID), new { id = createdTaskViewModel.Id }, createdTaskViewModel);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Update")]
        public IActionResult Put(int id, TaskUpdateDto taskViewModel)
        {
            if (id != taskViewModel.Id)
            {
                return BadRequest("IDs don't match!");
            }

            var task = _taskService.Fetch(id);

            if (task == null)
            {
                return NotFound();
            }
            task.Title = taskViewModel.Title;
            task.Description = taskViewModel.Description;
            task.BriefDescription = taskViewModel.BriefDescription;
            task.Description = taskViewModel.Description;
            task.AssignedUserId = taskViewModel.AssignedUserId;

            task.AttachedFiles = _taskFileService.Set().Where(a => a.TaskId == task.Id).ToList();
            if (task.AttachedFiles == null)
            {
                foreach (var item in taskViewModel.AttachedFiles)
                {
                    var taskFile = _mapper.Map<TaskFile>(item);
                    _taskFileService.Save(taskFile);
                }
            }
            else
            {
                task.AttachedFiles = _mapper.Map<List<TaskFile>>(taskViewModel.AttachedFiles);
            }
            _taskService.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Delete")]
        public IActionResult Delete(int id)
        {
            var task = _taskService.Fetch(id);

            if (task == null)
            {
                return NotFound();
            }

            _taskService.Delete(task);

            return NoContent();
        }
    }
}