using AutoMapper;
using Codebridge.Domain.Models;
using Codebridge.Resources;


namespace Codebridge.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Dog, GetDogsResource>();
            CreateMap<Dog, SaveDogResource>();
        }
    }
}
