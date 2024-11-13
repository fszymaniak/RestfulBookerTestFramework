namespace RestfulBookerTestFramework.Tests.Api.Drivers.Common;

public interface IRequestDriver
{
    public Task<RestResponse> SendGetRequestAsync(string endpoint);
    
    public Task<RestResponse> SendPostRequestAsync(string endpoint, object body);
    
    public Task<RestResponse> SendPutRequestAsync(string endpoint, object body);
    
    public Task<RestResponse> SendPatchRequest(string endpoint, object body);
    
    public RestResponse SendDeleteRequest(string endpoint);
}
