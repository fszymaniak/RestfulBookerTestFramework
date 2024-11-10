namespace RestfulBookerTestFramework.Tests.Api.Drivers.Common;

public interface IRequestDriver
{
    public RestResponse SendGetRequest(string endpoint);
    
    public RestResponse SendPostRequest(string endpoint, object body);
    
    public RestResponse SendPutRequest(string endpoint, object body);
    
    public RestResponse SendPatchRequest(string endpoint, object body);
    
    public RestResponse SendDeleteRequest(string endpoint);
}
