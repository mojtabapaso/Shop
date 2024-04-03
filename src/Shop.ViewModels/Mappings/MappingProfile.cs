using AutoMapper;
using Shop.Entities;
using Shop.ViewModels;
using Shop.ViewModels.Admin;
using Shop.ViewModels.Category;

namespace Shop.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreateMap<Tag, TagViewModel>();
        this.CreateMap<User, UserViewModel>();
        this.CreateMap<Address, AddressViewModel>();
        this.CreateMap<Product, ProductViewModel>();
        this.CreateMap<Brand, BrandViewModel>();
        this.CreateMap<Category, CategoryViewModel>();
        this.CreateMap<Comment, CommentViewModel>();
        this.CreateMap<Comment, CommentViewModel>();
    }

}
