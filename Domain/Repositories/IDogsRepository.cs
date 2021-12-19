using Codebridge.Domain.Models;
using Codebridge.Domain.Models.TechModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codebridge.Domain.Repositories
{
    public interface IDogsRepository
    {
        Task<IEnumerable<Dog>> GetDogsAsync(Sort_Pagination sort_page);

        Task AddDogAsync(Dog dog);
    }
}
