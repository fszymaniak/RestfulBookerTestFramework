using RestfulBookerTestFramework.Tests.Api.Extensions;
using RestfulBookerTestFramework.Tests.Api.Helpers;

namespace RestfulBookerTestFramework.Tests.Api.Drivers;

public sealed class RequestDriver(RestClient restClient, ScenarioContext scenarioContext, AuthTokenHelper authTokenHelper) : IRequestDriver
{
    public RestResponse SendGetRequest(string endpoint)
    {
        var request = new RestRequest(endpoint);
        request.WithAcceptHeader();

        RestResponse response;
        
        try
        {
            response = restClient.ExecuteGet(request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return response;
    }
    
    public RestResponse SendPostRequest(string endpoint, object body)
    {
        var request = new RestRequest(endpoint, Method.Post);
        request.WithAcceptHeader();
        request.WithBodyParameter(body);

        var cancellationTokenSource = new CancellationTokenSource();

        RestResponse response;
        
        try
        {
            response = restClient.ExecutePostAsync(request, cancellationTokenSource.Token).Result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return response;
    }

    public RestResponse SendDeleteRequest(string endpoint)
    {
        string token = authTokenHelper.GetToken();
        var request = new RestRequest(endpoint, Method.Delete);
        request.WithAcceptHeader();
        request.WithCookieTokenHeader(token);

        var cancellationTokenSource = new CancellationTokenSource();

        RestResponse response;
        
        try
        {
            response = restClient.ExecuteDeleteAsync(request, cancellationTokenSource.Token).Result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return response;
    }
}