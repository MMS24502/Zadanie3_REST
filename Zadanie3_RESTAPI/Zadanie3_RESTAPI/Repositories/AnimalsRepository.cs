using MySqlConnector;
using Zadanie3_RESTAPI.Models;

namespace Zadanie3_RESTAPI.Repositories;

public class AnimalsRepository : IAnimalsRepository
{
    private IConfiguration _configuration;

    public AnimalsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        using var con = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var cmd = new MySqlCommand();
        cmd.Connection = con;
        cmd.CommandText = $"SELECT * FROM Animal ORDER BY {orderBy} ASC";

        var dr = cmd.ExecuteReader();
        var animals = new List<Animal>();

        while (dr.Read())
        {
            var grade = new Animal
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["CATEGORY"].ToString(),
                Area = dr["AREA"].ToString()
            };
            animals.Add(grade);
        }

        return animals;
    }
    
    public int AddAnimal(Animal animal)
    {
        using var con = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new MySqlCommand();
        cmd.Connection = con;
        cmd.CommandText =
            $"INSERT INTO Animal (Name, Description, Category, Area) VALUES (@Name, @Description, @Category, @Area";
        
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int UpdateAnimal(Animal animal)
    {
        using var con = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new MySqlCommand();
        cmd.Connection = con;
        cmd.CommandText =
            $"UPDATE Animal SET Name = @Name, Description = @Description, Category = @Category, Area = @Area WHERE IdAnimal = @IdAnimal";
        
        cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int DeleteAnimal(int idAnimal)
    {
        using var con = new MySqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new MySqlCommand();
        cmd.Connection = con;
        cmd.CommandText = $"DELETE FROM Animal WHERE IdAnimal = @IdAnimal";
        
        cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}