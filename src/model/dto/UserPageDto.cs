namespace TestingApi.dto;

public class UserPageDto
{
    public int page { get; set; }
    public int per_page { get; set; }
    public int total { get; set; }
    public int total_pages { get; set; }
    public List<UserDto> data { get; set; }
    public SupportDto support { get; set; }

    public override string ToString()
    {
        return $"{nameof(page)}: {page}, {nameof(per_page)}: {per_page}, {nameof(total)}: {total}, " +
               $"{nameof(total_pages)}: {total_pages}, {nameof(data)}: {string.Join(", ", data)}, {nameof(support)}: {support}";
    }
}