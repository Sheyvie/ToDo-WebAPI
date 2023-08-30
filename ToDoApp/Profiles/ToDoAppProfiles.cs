using ToDoApp.Responses;
using ToDoApp.Models;
using ToDoApp.Requests;
using AutoMapper;

namespace ToDoApp.Profiles
{
    public class ToDoAppProfiles:Profile

    {
        public ToDoAppProfiles()
        {
            //user
            CreateMap<AddUser, User>().ReverseMap();
            CreateMap<UserResponse, User>().ReverseMap();
            
            //task
            CreateMap<AddTask, ToDoList>().ReverseMap();
            CreateMap<ToDoListResponse, ToDoList>().ReverseMap();


        }
    }
}
