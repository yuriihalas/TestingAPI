namespace TestingApi.dto;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Avatar { get; set; }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(Email)}: {Email}, {nameof(FirstName)}: " +
               $"{FirstName}, {nameof(LastName)}: {LastName}, {nameof(Avatar)}: {Avatar}";
    }
}