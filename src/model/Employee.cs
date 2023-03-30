namespace TestingApi.dto;

public class Employee
{
    public string Name { get; set; }
    public string Job { get; set; }
    public string Id { get; set; }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Job)}: {Job}, {nameof(Id)}: {Id}";
    }
}