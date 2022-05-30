using AutoMapper;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<UserViewModel, User>();
        CreateMap<RegisterViewModel, User>();
        CreateMap<SaveUserViewModel, User>();
        CreateMap<SaveUserViewModel, DT>();
    }
}