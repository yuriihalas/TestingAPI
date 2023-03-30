using System.Net;
using log4net;
using log4net.Config;
using Newtonsoft.Json;
using TestingApi.dto;
using Xunit;

namespace TestingApi.test;

public class ApiTests : IDisposable
{
    public static readonly ILog Log = LogManager.GetLogger(typeof(ApiTests));
    private static ApiClient _apiClient;
    private static readonly Mapper _mapper = new();

    public ApiTests()
    {
        XmlConfigurator.Configure(new FileInfo($"{ResourceUtils.GetSourceDir()}/log4net.config"));
        ResourceUtils.LoadResource();
        _apiClient = new ApiClient();
    }

    [Fact]
    public async void TestGetAllUsers()
    {
        var expectedPageNumber = 2;
        var responseMessage = await _apiClient.GetAllUsersAsync(expectedPageNumber);
        var actualResult = _mapper.getModel<UserPageDto, UserPage>(responseMessage).Result;

        Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        Assert.Equal(expectedPageNumber, actualResult.PageNumber);
        Assert.NotEmpty(actualResult.Users);
        Assert.Equal(expectedPageNumber * actualResult.ResultsPerPage, actualResult.Total);
    }

    [Fact]
    public async void TestGetUser()
    {
        var expectedId = 2;
        var responseMessage = await _apiClient.GetUserAsync(expectedId);

        var actualResult = await _mapper.getModel<UserInfoDto, UserInfo>(responseMessage);

        Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        Assert.Equal(expectedId, actualResult.User.Id);
        Assert.NotNull(actualResult.User.Avatar);
        Assert.NotNull(actualResult.User.Email);
        Assert.NotNull(actualResult.User.FirstName);
        Assert.NotNull(actualResult.User.LastName);
        Assert.NotNull(actualResult.User.Avatar);
        Assert.NotNull(actualResult.Support);
        Assert.NotNull(actualResult.Support.Text);
        Assert.NotNull(actualResult.Support.Url);
    }

    [Fact]
    public async void TestUserNotFound()
    {
        var expectedId = 23;
        var responseMessage = await _apiClient.GetUserAsync(expectedId);

        //using readAsStringAsync because need to check empty json 
        var actualResult = await responseMessage.Content.ReadAsStringAsync();
        
        Assert.Equal(HttpStatusCode.NotFound, responseMessage.StatusCode);
        Assert.Equal("{}", actualResult);
    }

    public void Dispose()
    {
        _apiClient.Dispose();
    }
}