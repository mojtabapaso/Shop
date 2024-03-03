using AutoMapper;
using Shop.Entities;
using Shop.ViewModels;
using Shop.ViewModels.Admin;

namespace Shop.Mappings;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		this.CreateMap<Tag, TagViewModel>();
		this.CreateMap<User, UserViewModel>();
		//this.CreateMap<ProductViewModel, Product>();

		this.CreateMap<Address, AddressViewModel>();

		this.CreateMap<List<AddressViewModel>, List<Address>>()
		.ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity));

		this.CreateMap<List<ProductViewModel>, List<Product>>()
		.ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity));

		//this.CreateMap<List<Address>, List<AddressViewModel>>()
		//.ForMember(dest => dest, opt => opt.MapFrom(src => src));

		this.AddGlobalIgnore("Item");
		this.AllowNullCollections = true;
		this.AllowNullDestinationValues = true;
		
	}

}
