using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace TodoREST
{
    public interface IHttpClientHandlerService
    {
        HttpClientHandler GetInsecureHandler();
    }
}
