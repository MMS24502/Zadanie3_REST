using Zadanie3_RESTAPI.Models;

namespace Zadanie3_RESTAPI.Repositories;

public interface IAnimalsRepository
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    int AddAnimal(Animal animal);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal); 
}