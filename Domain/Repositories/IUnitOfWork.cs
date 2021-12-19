using System.Threading.Tasks;

namespace Codebridge.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }   
}
