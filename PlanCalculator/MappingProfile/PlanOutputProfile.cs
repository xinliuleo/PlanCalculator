using AutoMapper;
using PlanCalculator.Models;
using System;

namespace PlanCalculator.MappingProfile
{
    public class PlanOutputProfile : Profile
    {
        public PlanOutputProfile()
        {
            CreateMap<PlanOutput, PlanOutputDto>()
                .ForMember(dest => dest.FormattedDeposit,
                    opts => opts.MapFrom(
                        src => src.Deposit.ToString("#0%")
                    ))
                .ForMember(dest => dest.RoundedInstalmentAmount,
                    opts => opts.MapFrom(
                        src => Math.Round(src.InstalmentAmount,2)
                    ));
        }
    }
}
