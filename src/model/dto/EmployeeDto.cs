namespace TestingApi.dto;

public class EmployeeDto
{
    public string name { get; set; }
    public string job { get; set; }
    public string id { get; set; }

    public override string ToString()
    {
        return $"{nameof(name)}: {name}, {nameof(job)}: {job}, {nameof(id)}: {id}";
    }
}