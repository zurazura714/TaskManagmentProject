using AutoMapper;
using System.Runtime.InteropServices;
using TaskManagmentProject.Common.DTOS;
using TaskManagmentProject.Domain.Models;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<TaskDomain, TaskDomainCreateDto>().ReverseMap()
            .ForMember(
                dest => dest.AttachedFiles,
                opt => opt.MapFrom(src => src.AttachedFiles)); ;
        CreateMap<TaskDomain, TaskUpdateDto>().ReverseMap();
    }
}
public class TaskFileProfile : Profile
{
    public TaskFileProfile()
    {
        CreateMap<TaskFile, TaskFileCreateDto>().ReverseMap();
    }
}