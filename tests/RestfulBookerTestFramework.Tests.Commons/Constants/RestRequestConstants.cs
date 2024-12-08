namespace RestfulBookerTestFramework.Tests.Commons.Constants;

public static class RestRequestConstants
{
    public static class Headers
    {
        public static readonly string Accept = "Accept";
    
        public static readonly string Cookie = "Cookie";
    
        public static readonly string ContentType = "Content-Type";
    }

    public static class Values
    {
        public static readonly string ApplicationJson = "application/json";

        public static readonly string TokenFormat = "token={0}";
    }
}