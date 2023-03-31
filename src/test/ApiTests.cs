using System.Net;
using TestingApi.main.sharp;
using TestingApi.main.sharp.model;
using Xunit;

namespace TestingApi.test;

public class ApiTests : BaseTest
{
    [Fact]
    public async void GetAllUsersTest()
    {
        var expectedPageNumber = 2;
        var responseMessage = await ApiClient.GetAllUsersAsync(expectedPageNumber);
        var actualUserPage = JsonUtils.GetModel<UserPage>(responseMessage).Result;

        Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        Assert.Equal(expectedPageNumber, actualUserPage.PageNumber);
        Assert.NotEmpty(actualUserPage.Users);
        Assert.Equal(expectedPageNumber * actualUserPage.ResultsPerPage, actualUserPage.Total);
    }

    [Fact]
    public async void GetUserInfoTest()
    {
        var expectedId = 2;
        var responseMessage = await ApiClient.GetUserAsync(expectedId);

        var actualUserInfo = await JsonUtils.GetModel<UserInfo>(responseMessage);

        Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        Assert.Equal(expectedId, actualUserInfo.User.Id);
        Assert.NotNull(actualUserInfo.User.Avatar);
        Assert.NotNull(actualUserInfo.User.Email);
        Assert.NotNull(actualUserInfo.User.FirstName);
        Assert.NotNull(actualUserInfo.User.LastName);
        Assert.NotNull(actualUserInfo.User.Avatar);
        Assert.NotNull(actualUserInfo.Support);
        Assert.NotNull(actualUserInfo.Support.Text);
        Assert.NotNull(actualUserInfo.Support.Url);
    }

    [Fact]
    public async void UserNotInfoFoundTest()
    {
        var expectedId = 23;
        var responseMessage = await ApiClient.GetUserAsync(expectedId);

        //using readAsStringAsync because need to check empty json 
        var actualResult = await responseMessage.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.NotFound, responseMessage.StatusCode);
        Assert.Equal("{}", actualResult);
    }

    [Fact]
    public async void CreateUserTest()
    {
        Employee employee = new Employee();
        employee.Job = "unknown";
        employee.Name = "John";

        string expectedFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";

        var responseMessage = await ApiClient.PostUserAsync(employee);
        var actualEmployee = await JsonUtils.GetModel<Employee>(responseMessage);

        DateTime actualDate = DateUtils.GetDateTime(actualEmployee.CreatedAt, expectedFormat);
        DateTime expectedDate = DateUtils.GetDateTime(DateTime.UtcNow.ToString(expectedFormat), expectedFormat);

        Assert.Equal(HttpStatusCode.Created, responseMessage.StatusCode);
        Assert.Equal(employee.Job, actualEmployee.Job);
        Assert.Equal(employee.Name, actualEmployee.Name);
        Assert.NotEmpty(actualEmployee.Id);
        Assert.InRange(actualDate, expectedDate.AddSeconds(-1), expectedDate.AddSeconds(1));
    }

    [Fact]
    public async void UpdateUserTest()
    {
        Employee employee = new Employee();
        employee.Job = "JobType";
        employee.Name = "SimpleName";

        int id = 2;
        string expectedFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";

        var responseMessage = await ApiClient.UpdateUserAsync(employee, id);
        var actualEmployee = await JsonUtils.GetModel<Employee>(responseMessage);

        DateTime actualDate = DateUtils.GetDateTime(actualEmployee.UpdatedAt, expectedFormat);
        DateTime expectedDate = DateUtils.GetDateTime(DateTime.UtcNow.ToString(expectedFormat), expectedFormat);

        Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        Assert.Equal(employee.Job, actualEmployee.Job);
        Assert.Equal(employee.Name, actualEmployee.Name);
        Assert.InRange(actualDate, expectedDate.AddSeconds(-1), expectedDate.AddSeconds(1));
    }

    [Fact]
    public async void PartialUpdateUserTest()
    {
        Employee employee = new Employee();
        employee.Job = "Updated";

        int id = 332;
        string expectedFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";

        var responseMessage = await ApiClient.PatchUserAsync(employee, id);
        var actualEmployee = await JsonUtils.GetModel<Employee>(responseMessage);

        DateTime actualDate = DateUtils.GetDateTime(actualEmployee.UpdatedAt, expectedFormat);
        DateTime expectedDate = DateUtils.GetDateTime(DateTime.UtcNow.ToString(expectedFormat), expectedFormat);

        Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        Assert.Equal(employee.Job, actualEmployee.Job);
        Assert.Equal(employee.Name, actualEmployee.Name);
        Assert.InRange(actualDate, expectedDate.AddSeconds(-1), expectedDate.AddSeconds(1));
    }
}