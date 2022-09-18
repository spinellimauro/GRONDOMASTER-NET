using AutoMapper;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<UserViewModel, ApplicationUser>();
        CreateMap<RegisterViewModel, ApplicationUser>();
        CreateMap<SaveUserViewModel, ApplicationUser>();
        CreateMap<SaveUserViewModel, DT>();
        CreateMap<RegisterViewModel, DT>()
        .ForPath(r => r.Equipo.EquipoSofifa, opt => opt.MapFrom(r => r.Equipo));
        CreateMap<JugadoresSoFifaViewModel, Jugador>();
        CreateMap<EquipoSoFifaViewModel, EquipoSofifa>();
    }
}