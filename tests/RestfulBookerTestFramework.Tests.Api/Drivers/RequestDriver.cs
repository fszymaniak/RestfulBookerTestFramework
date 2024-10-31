using RestfulBookerTestFramework.Tests.Api.Extensions;

namespace RestfulBookerTestFramework.Tests.Api.Drivers;

public sealed class RequestDriver(RestClient restClient) : IRequestDriver
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
}