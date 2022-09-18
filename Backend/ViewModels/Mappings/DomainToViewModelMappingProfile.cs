using AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {

        CreateMap<ApplicationUser, UserViewModel>();
        CreateMap<ApplicationUser, RegisterViewModel>();
        CreateMap<ApplicationUser, SaveUserViewModel>();
        CreateMap<DT, SaveUserViewModel>();
        CreateMap<DT, RegisterViewModel>()
        .ForPath(r => r.Equipo, opt => opt.MapFrom(r => r.Equipo.EquipoSofifa));
        CreateMap<Jugador, JugadoresSoFifaViewModel>();
        CreateMap<EquipoSofifa, EquipoSoFifaViewModel>();
    }

}