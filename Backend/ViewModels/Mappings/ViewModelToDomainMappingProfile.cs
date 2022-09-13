using AutoMapper;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<UserViewModel, ApplicationUser>();
        CreateMap<RegisterViewModel, ApplicationUser>();
        CreateMap<SaveUserViewModel, ApplicationUser>();
        CreateMap<SaveUserViewModel, DT>();
    }
}