using AutoMapper;
using System.Runtime.InteropServices;
using TaskManagmentProject.Common.DTOS;
using TaskManagmentProject.Domain.Models;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<TaskDomain, TaskDto>().ReverseMap();
    }
}