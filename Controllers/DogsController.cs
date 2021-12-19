using AutoMapper;
using Codebridge.Domain.Models;
using Codebridge.Domain.Models.TechModels;
using Codebridge.Domain.Services;
using Codebridge.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Codebridge.Controllers
{

    [ApiController]
    [Route("")]
    public class DogsController : Controller
    {
        private readonly IDogsService _dogs;
        private readonly IMapper _mapper;

        public DogsController(IDogsService dogsService, IMapper mapper)
        {
            _dogs = dogsService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("dogs")]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IEnumerable<GetDogsResource>> GetDogsAsync([FromQuery] Sort_Pagination sort_page)
        {
            var dogs = await _dogs.GetDogsAsync(sort_page);
            var resources = _mapper.Map<IEnumerable<Dog>, IEnumerable<GetDogsResource>>(dogs);
            return resources;
        }


        [HttpPost]
        [Route("dog")]
        [ProducesResponseType(typeof(SaveDogResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> SaveDogAsync([FromBody] SaveDogResource resource)
        {      
            var dog = _mapper.Map<SaveDogResource, Dog>(resource);
            var result = await _dogs.SaveDogAsync(dog);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var dogResource = _mapper.Map<Dog, SaveDogResource>(result.Dog);
            return Ok(dogResource);
        }
    }
}
