using AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {

        CreateMap<User, UserViewModel>();
        CreateMap<User, RegisterViewModel>();
        CreateMap<User, SaveUserViewModel>();
        CreateMap<DT, SaveUserViewModel>();
    }

}