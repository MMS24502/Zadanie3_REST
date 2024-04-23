using System.ComponentModel.DataAnnotations;

namespace Zadanie3_RESTAPI.Models;

public class Animal
{
    public int IdAnimal { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; }

    [StringLength(200)]
    public string Description { get; set; }

    [Required]
    public string Category { get; set; }

    public string Area { get; set; }
}