using System.Text.Json.Serialization;

namespace API.Data;

public class Person
{
    
    [JsonIgnore]
    public int PersonId { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }

    public string NationalIdentity { get; set; }

    public DateTime BirthDate { get; set; }
    
}