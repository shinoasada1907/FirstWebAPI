using AutoMapper;
using FirstWebAPI.Data;
using FirstWebAPI.Model;

namespace FirstWebAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Book, BookModel>().ReverseMap();
        }
    }
}
