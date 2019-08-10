using AutoMapper;
using PlanCalculator.Models;

namespace PlanCalculator.MappingProfile
{
    public class PlanInputProfile : Profile
    {
        public PlanInputProfile()
        {
            CreateMap<PlanInputDto, PlanInput>();
        }
    }
}
