namespace TestingApi.dto;

public class UserDto
{
    public int id { get; set; }
    public string email { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string avatar { get; set; }

    public override string ToString()
    {
        return $"{nameof(id)}: {id}, {nameof(email)}: {email}, {nameof(first_name)}: " +
               $"{first_name}, {nameof(last_name)}: {last_name}, {nameof(avatar)}: {avatar}";
    }
}