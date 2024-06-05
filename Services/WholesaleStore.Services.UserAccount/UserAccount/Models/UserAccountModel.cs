using AutoMapper;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Services.UserAccount.UserAccount.Models;

public class UserAccountModel
{
    public Guid Id { get; set; }
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Name { get; set; } = default!;
    //public UserStatus Status { get; set; } = default!;
    //public UserRole Role { get; set; } = default!;
    public string Avatar { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;
    //public virtual ICollection<Order> Orders { get; set; } = default!;
}

public class UserAccountModelProfile : Profile
{
    public UserAccountModelProfile()
    {
        CreateMap<User, UserAccountModel>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Uid))
            .ForMember(d => d.Email, o => o.MapFrom(s => s.Email))
            .ForMember(d => d.Password, o => o.MapFrom(s => s.Password))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.Avatar, o => o.MapFrom(s => s.Avatar))
            .ForMember(d => d.PhoneNumber, o => o.MapFrom(s => s.PhoneNumber))
            .ForMember(d => d.Address, o => o.MapFrom(s => s.Address))
            ;
    }
}
