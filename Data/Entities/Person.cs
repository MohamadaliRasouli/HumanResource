

namespace HumanResource.Data.Entities;

public class Person
{
    public int PersonId { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string NationalIdentity { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public byte[] Photo { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();
   
    
}