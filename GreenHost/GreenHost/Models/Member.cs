namespace GreenHost.Models;

public class Member : BaseEntity
{
    public string Fullname { get; set; }
    public string Image { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }

}
