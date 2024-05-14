using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace CqrsMediatrExample_
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Student, StudentDto>();
            CreateMap<Course, CourseDto>();
            CreateMap<Journal, JournalDto>();
            CreateMap<Post, PostDto>();
            CreateMap<Lesson, LessonDto>();

            CreateMap<UserCreateDto, User>();
        }
    }
}
