using AutoMapper;
using ToDoApp.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Responses;
using ToDoApp.Services.Iservices;
using ToDoApp.Requests;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IToDoListService _toDoListService;

        public ToDoListController(IToDoListService service, IMapper mapper)
        {
            _mapper = mapper;
            _toDoListService = service;

        }

        [HttpPost]
        public async Task<ActionResult<TaskSuccess>> AddTask(AddTask newTaskName)
        {
            //mapping
            try
            {
                var task = _mapper.Map<ToDoList>(newTaskName);
                var res = await _toDoListService.AddTaskAsync(task);
                return CreatedAtAction(nameof(AddTask), new TaskSuccess(201, res));
            }
            catch (Exception ex)
            {

                return BadRequest(new TaskSuccess(400, ex.Message));
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoListResponse>>>GetAll()
        {
            var response = await _toDoListService.GetAllAsync();
            var tasks = _mapper.Map<IEnumerable<ToDoListResponse>>(response);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetTask(Guid id)
        {
            var response = await _toDoListService.GetTaskByIdAsync(id);
            if (response == null)
            {
                return NotFound(new TaskSuccess(404, "Course not found"));
            }
            var course = _mapper.Map<ToDoListResponse>(response);
            return Ok(course);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskSuccess>> SelectTask(Guid id)
        {
            var response = await _toDoListService.GetTaskByIdAsync(id);
            if (response == null)
            {
                return NotFound(new TaskSuccess(404, "task not found"));
            }
            //update
            
            var res = await _toDoListService.DeleteTaskAsync(response);

            return Ok(new TaskSuccess(204, res));
        }

    }
}
