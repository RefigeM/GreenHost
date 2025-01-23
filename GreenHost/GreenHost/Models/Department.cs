namespace GreenHost.Models;

public class Department : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Member> Members { get; set; }

}
