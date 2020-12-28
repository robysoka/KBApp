using AutoMapper;
using KBDataAccessLibrary.Models;
using KBDataManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KBDataManager.Mapping
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AgeCategory, AgeCategoryViewModel>()
                .ReverseMap();
        }
    }
}
