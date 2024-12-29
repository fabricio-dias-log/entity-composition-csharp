namespace EntityComposition.Entities;

public class Department
{
    public string Name { get; set; }

    public Department()
    {
        
    }

    public Department(string name)
    {
        this.Name = name;
    }
}