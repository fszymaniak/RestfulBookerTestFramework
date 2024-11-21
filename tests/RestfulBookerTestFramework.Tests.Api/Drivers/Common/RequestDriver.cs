using RestfulBookerTestFramework.Tests.Api.Extensions;

namespace RestfulBookerTestFramework.Tests.Api.Drivers.Common;

public sealed class RequestDriver(RestClient restClient, ScenarioContext scenarioContext) : IRequestDriver
{
    private RestResponse _response;

    public async Task<RestResponse> SendGetRequestAsync(string endpoint)
    {
        try
        {
            _response = await ExecuteRequestAsync(endpoint, Method.Get);
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
        try
        {
            _response = await ExecuteRequestAsync(endpoint, Method.Post, body);
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
        try
        {
            _response = await ExecuteRequestAsync(endpoint, Method.Put, body);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return _response;
    }
    
    public async Task<RestResponse> SendPatchRequestAsync(string endpoint, object body)
    {
        try
        {
            _response = await ExecuteRequestAsync(endpoint, Method.Patch, body);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return _response;
    }

    public async Task<RestResponse> SendDeleteRequestAsync(string endpoint)
    {
        try
        {
            _response = await ExecuteRequestAsync(endpoint, Method.Delete);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return _response;
    }
    
    private async Task<RestResponse> ExecuteRequestAsync(string endpoint, Method method, object body = null)
    {
        var request = new RestRequest(endpoint, method);
        request.SetupRequestWithAuthorizationAndBody(body, method, scenarioContext);

        return method switch
        {
            Method.Get => await restClient.ExecuteGetAsync(request, GetCancellationToken()),
            Method.Post => await restClient.ExecutePostAsync(request, GetCancellationToken()),
            Method.Put => await restClient.ExecutePutAsync(request, GetCancellationToken()),
            Method.Patch => await restClient.ExecutePatchAsync(request, GetCancellationToken()),
            Method.Delete => await restClient.ExecuteDeleteAsync(request, GetCancellationToken()),
            _ => throw new ArgumentOutOfRangeException(nameof(method), method, null)
        };
    }

    private CancellationToken GetCancellationToken()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        return cancellationTokenSource.Token;
    }
}
