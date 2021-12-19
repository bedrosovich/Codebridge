using Codebridge.Domain.IServices.Communication;
using Codebridge.Domain.Models;
using Codebridge.Domain.Models.TechModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codebridge.Domain.Services
{
    public interface IDogsService
    {
        Task<IEnumerable<Dog>> GetDogsAsync(Sort_Pagination sort_page);
        Task<SaveDogResponse> SaveDogAsync(Dog dog);
    }
}
