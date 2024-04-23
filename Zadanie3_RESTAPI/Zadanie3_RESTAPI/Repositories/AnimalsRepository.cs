using Zadanie3_RESTAPI.Models;

namespace Zadanie3_RESTAPI.Repositories;

public class AnimalsRepository : IAnimalsRepository
{
    public Task<List<Animal>> GetAllAnimalsAsync(string orderBy)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAnimalAsync(int idAnimal)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAnimalAsync(Animal animal)
    {
        throw new NotImplementedException();
    }

    public Task AddAnimalAsync(Animal animal)
    {
        throw new NotImplementedException();
    }
}