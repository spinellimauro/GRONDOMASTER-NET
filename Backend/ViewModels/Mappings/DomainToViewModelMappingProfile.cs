using AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {

        CreateMap<ApplicationUser, UserViewModel>();
        CreateMap<ApplicationUser, RegisterViewModel>();
        CreateMap<ApplicationUser, SaveUserViewModel>();
        CreateMap<DT, SaveUserViewModel>();
        CreateMap<Jugador, JugadoresSoFifaViewModel>();
    }

}