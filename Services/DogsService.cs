using Codebridge.Domain.IServices.Communication;
using Codebridge.Domain.Models;
using Codebridge.Domain.Models.TechModels;
using Codebridge.Domain.Repositories;
using Codebridge.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codebridge.Services
{
    public class DogsService : IDogsService
    {
        private readonly IDogsRepository _dogs;
		private readonly IUnitOfWork _unitOfWork;

		public DogsService(IDogsRepository dogsRepository, IUnitOfWork unitOfWork)
        {
            _dogs = dogsRepository;
			_unitOfWork = unitOfWork;
		}

        public async Task<IEnumerable<Dog>> GetDogsAsync(Sort_Pagination sort_page)
        {
            return await _dogs.GetDogsAsync(sort_page);
        }

		public async Task<SaveDogResponse> SaveDogAsync(Dog dog)
		{

			try
			{
				await _dogs.AddDogAsync(dog);
				await _unitOfWork.CompleteAsync();

				return new SaveDogResponse(dog);
			}
			catch (Exception ex)
			{
				
				return new SaveDogResponse($"An error occurred when saving the dog: {ex.Message}");
			}
		}
	}
}
