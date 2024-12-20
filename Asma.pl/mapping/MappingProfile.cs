﻿using Asmaa.DAL.Model;
using Asmaa.Pl.Areas.DashBord.ViewModels;
using Asmaa.Pl.Areas.DashBord.ViewModels.FeaturesVM;
using AutoMapper;
using Asmaa.Pl.Areas.DashBord.ViewModels.TestimonalVM;
using Asmaa.Pl.Areas.DashBord.ViewModels.MainHomeVM;

namespace Asmaa.Pl.mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<LastProductCreateVM, LastProduct>().ReverseMap();
            CreateMap<LastProduct, LastProductIndexVM>();
            CreateMap<Feature, FeatureIndexVM>();
            CreateMap<FeaturesCreateVM, Feature>().ReverseMap();
            CreateMap<TestimonalCreateVM, Testimonal>().ReverseMap();
            CreateMap<Testimonal, TestimonalIndexVM>();
            CreateMap<MainHomeCreateVM, MainHome>().ReverseMap();
            CreateMap<MainHome, MainHomeIndexVM>();
        }
    }
}

