using AutoMapper;
using Microsoft.AspNetCore.Http;
using ToDoApp.Services.Iservices;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Requests;
using ToDoApp.Responses;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserServices _userService;

        public UserController(IUserServices service, IMapper mapper)
        {
            _mapper = mapper;
            _userService = service;
        }

        [HttpPost]
        public async Task<ActionResult<TaskSuccess>> AddUser(AddUser newUser)
        {

            
            var user = _mapper.Map<User>(newUser);
            var res = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(AddUser), new TaskSuccess(201, res));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUsers()
        {
            var response = await _userService.GetAllUsersAsync();
            var users = _mapper.Map<IEnumerable<UserResponse>>(response);
            return Ok(users);
        }
        
    }
}
