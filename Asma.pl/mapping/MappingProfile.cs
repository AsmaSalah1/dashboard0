using Asmaa.DAL.Model;
using Asmaa.Pl.Areas.DashBord.ViewModels;
using Asmaa.Pl.Areas.DashBord.ViewModels.FeaturesVM;
using AutoMapper;

namespace Asmaa.Pl.mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<LastProductCreateVM, LastProduct>().ReverseMap();
            CreateMap<LastProduct, LastProductIndexVM>();
            CreateMap<Feature,FeatureIndexVM>();
            CreateMap<FeaturesCreateVM, Feature>();
        }
    }
}
