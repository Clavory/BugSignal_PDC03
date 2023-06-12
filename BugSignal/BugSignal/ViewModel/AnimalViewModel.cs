using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using System.IO;
using BugSignal.Model;

using System.Threading.Tasks;


namespace BugSignal.ViewModel
{
    public class AnimalViewModel
    {
        // Call Database 

        private Services.DatabaseContext getContext()
        {
            return new Services.DatabaseContext();

        }

        // Insert Records
        public int InsertAnimal(AnimalModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Animals.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        // Retrieves Records 

        public async Task<List<AnimalModel>> GetAllAnimals()
        {
            var _dbContext = getContext();
            var res = await _dbContext.Animals.ToListAsync();
            return res;
        }

        // Delete Records
        public int DeleteAnimal(AnimalModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Animals.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        // Update Records 
        public async Task<int> UpdateAnimal(AnimalModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Animals.Update(obj);
            int c = await _dbContext.SaveChangesAsync();
            return c;
        }
    }
}
