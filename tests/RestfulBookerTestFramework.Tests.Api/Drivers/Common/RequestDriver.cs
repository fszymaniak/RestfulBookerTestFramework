using RestfulBookerTestFramework.Tests.Api.Extensions;

namespace RestfulBookerTestFramework.Tests.Api.Drivers.Common;

public sealed class RequestDriver(RestClient restClient, ScenarioContext scenarioContext) : IRequestDriver
{
    private RestResponse _response;

    public async Task<RestResponse> SendGetRequestAsync(string endpoint)
    {
        var request = new RestRequest(endpoint);
        request.WithAcceptHeader();

        try
        {
            _response = await restClient.ExecuteGetAsync(request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return _response;
    }
    
    public async Task<RestResponse> SendPostRequestAsync(string endpoint, object body)
    {
        var request = new RestRequest(endpoint, Method.Post);
        request.WithAcceptHeader();
        request.WithBodyParameter(body);

        var cancellationTokenSource = new CancellationTokenSource();

        try
        {
            _response = await restClient.ExecutePostAsync(request, cancellationTokenSource.Token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return _response;
    }
    
    public async Task<RestResponse> SendPutRequestAsync(string endpoint, object body)
    {
        var token = scenarioContext.GetAuthTokenResponse();
        var request = new RestRequest(endpoint, Method.Put);
        request.WithAcceptHeader();
        request.WithContentTypeHeader();
        request.WithCookieTokenHeader(token.Token);
        request.WithBodyParameter(body);

        var cancellationTokenSource = new CancellationTokenSource();

        try
        {
            _response = await restClient.ExecutePutAsync(request, cancellationTokenSource.Token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return _response;
    }
    
    public RestResponse SendPatchRequest(string endpoint, object body)
    {
        var token = scenarioContext.GetAuthTokenResponse();
        var request = new RestRequest(endpoint, Method.Patch);
        request.WithAcceptHeader();
        request.WithContentTypeHeader();
        request.WithCookieTokenHeader(token.Token);
        request.WithBodyParameter(body);

        var cancellationTokenSource = new CancellationTokenSource();

        try
        {
            _response = restClient.ExecutePatchAsync(request, cancellationTokenSource.Token).Result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return _response;
    }

    public RestResponse SendDeleteRequest(string endpoint)
    {
        var token = scenarioContext.GetAuthTokenResponse();
        var request = new RestRequest(endpoint, Method.Delete);
        request.WithAcceptHeader();
        request.WithCookieTokenHeader(token.Token);

        var cancellationTokenSource = new CancellationTokenSource();

        try
        {
            _response = restClient.ExecuteDeleteAsync(request, cancellationTokenSource.Token).Result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return _response;
    }
}