using AutoMapper;
using KBDataAccessLibrary.Models;
using KBDataManager.InputModels;
using KBDataManager.ViewModels;

namespace KBDataManager.Mapping
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AgeCategory, AgeCategoryViewModel>()
                .ReverseMap();

            CreateMap<UserRegistrationInputModel, User>()
                .ReverseMap();

            CreateMap<UserRegistrationInputModel, Student>()
                .ReverseMap();

            CreateMap<Group, GroupViewModel>()
                .ReverseMap();
            CreateMap<Student, StudentDataViewModel>()
                .ReverseMap();
        }
    }
}
