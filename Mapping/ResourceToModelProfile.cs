using AutoMapper;
using Codebridge.Domain.Models;
using Codebridge.Resources;


namespace Codebridge.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveDogResource, Dog>();
        }
    }
}
