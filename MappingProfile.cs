using AutoMapper;
using EBookStore.Models;
using EBookStore.DTOs;

namespace EBookStore.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDto, Book>();
            CreateMap<AuthorDto, Author>();
        }
    
 
                
            
        }
    }
