using Codebridge.DB.Contexts;
using Codebridge.Domain.Models;
using Codebridge.Domain.Models.TechModels;
using Codebridge.Domain.Repositories;
using Codebridge.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Codebridge.DB.Repositories
{
    public class DogsRepository : BaseRepository, IDogsRepository
    {
        public DogsRepository(AppDbContext context) : base(context)
        {
        }

      

        public async Task<IEnumerable<Dog>> GetDogsAsync(Sort_Pagination sort_page)
        {
            Dog dog = new Dog();
            Type type = dog.GetType();
            PropertyInfo[] props = type.GetProperties();


            if (props.Any(x => x.Name.ToLower() == sort_page.attribute.ToLower()))
            {
                return await _context.Dogs
                    .OrderByPropertyName(sort_page.attribute, sort_page.order)
                    .Skip((sort_page.pageNumber - 1) * sort_page.PageSize)
                    .Take(sort_page.PageSize)
                    .ToListAsync();
            }
            else
            {
                return await _context.Dogs
                    .OrderBy(x => x.Id)
                    .Skip((sort_page.pageNumber - 1) * sort_page.PageSize)
                    .Take(sort_page.PageSize)
                    .ToListAsync();
            }
        }


        public async Task AddDogAsync(Dog dog)
        {
            Dog DbEntry = _context.Dogs.FirstOrDefault(p => p.Name == dog.Name);
            if (DbEntry != null)
            {
                throw new Exception($"Dog with name {dog.Name} already exists in DB");
            }
            else
            {
                await _context.Dogs.AddAsync(dog);
            }
        }
    }
}
