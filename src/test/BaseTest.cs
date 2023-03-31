using log4net;
using log4net.Config;

namespace TestingApi.test;

public class BaseTest : IDisposable
{
    public static readonly ILog Log = LogManager.GetLogger(typeof(BaseTest));
    protected readonly ApiClient ApiClient;

    protected BaseTest()
    {
        XmlConfigurator.Configure(new FileInfo($"{ResourceUtils.GetSourceDir()}/log4net.config"));
        ResourceUtils.LoadResource();
        ApiClient = new ApiClient();
    }

    public void Dispose()
    {
        ApiClient.Dispose();
    }
}