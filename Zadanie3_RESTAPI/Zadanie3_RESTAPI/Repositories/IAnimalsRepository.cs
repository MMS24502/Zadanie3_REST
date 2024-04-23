using Zadanie3_RESTAPI.Models;

namespace Zadanie3_RESTAPI.Repositories;

public interface IAnimalsRepository
{
    Task<List<Animal>> GetAllAnimalsAsync(string orderBy);
    Task AddAnimalAsync(Animal animal);
    Task UpdateAnimalAsync(Animal animal);
    Task DeleteAnimalAsync(int idAnimal); 
}