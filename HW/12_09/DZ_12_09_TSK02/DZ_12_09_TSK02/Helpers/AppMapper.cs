using AutoMapper;
using DZ_12_09_TSK02.Models;

namespace DZ_12_09_TSK02.Helpers
{
    public class AppMapper:Profile
    {
        public AppMapper()
        {
            CreateMap<TakenBook, Author>().ReverseMap();
            CreateMap<TakenBook, Book>().ReverseMap();
            CreateMap<TakenBook, User>().ReverseMap();
        }
    }
}