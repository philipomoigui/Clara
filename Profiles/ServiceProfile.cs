using AutoMapper;
using Clara.Models;
using Clara.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Profiles
{
    public class ServiceProfile: Profile
    {
        public ServiceProfile()
        {
            CreateMap<CreateServiceViewModel, Service>();
            CreateMap<Service, DetailViewModel>();
        }
    }
}
