using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagmentProject.Abstraction.IRepositories;
using TaskManagmentProject.Common.DTOS;
using TaskManagmentProject.Domain.Models;

namespace TaskManagmentProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;

        public TaskController(IMapper mapper, ITaskRepository taskRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        [HttpGet]
        [Authorize(Roles = "View")]
        public ActionResult<IEnumerable<TaskDto>> Get()
        {
            var userId = User.Claims.First().Value;
            var tasks = _taskRepository.Set()
                .Where(a => a.AssignedUserId == Convert.ToInt32(userId));
            var taskViewModels = _mapper.Map<List<TaskDto>>(tasks);
            return Ok(taskViewModels);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "View")]
        public ActionResult<TaskDto> GetById(int id)
        {
            var task = _taskRepository.Fetch(id);

            if (task == null)
            {
                return NotFound();
            }

            var taskViewModel = _mapper.Map<TaskDto>(task);
            return Ok(taskViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Create")]
        public ActionResult<TaskDto> Post(TaskDto taskViewModel)
        {
            var task = _mapper.Map<TaskDomain>(taskViewModel);
            task.CreatedAt = DateTime.Now;
            _taskRepository.Save(task);

            var createdTaskViewModel = _mapper.Map<TaskDto>(task);
            return CreatedAtAction(nameof(GetById), new { id = createdTaskViewModel.Id }, createdTaskViewModel);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Update")]
        public IActionResult Put(int id, TaskDto taskViewModel)
        {
            if (id != taskViewModel.Id)
            {
                return BadRequest();
            }

            var task = _taskRepository.Fetch(id);

            if (task == null)
            {
                return NotFound();
            }

            _mapper.Map(taskViewModel, task);
            _taskRepository.Save(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Delete")]
        public IActionResult Delete(int id)
        {
            var task = _taskRepository.Fetch(id);

            if (task == null)
            {
                return NotFound();
            }

            _taskRepository.Delete(task);

            return NoContent();
        }
    }
}