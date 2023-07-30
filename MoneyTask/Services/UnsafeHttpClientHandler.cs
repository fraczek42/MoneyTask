using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MoneyTask.Services
{
    public class UnsafeHttpClientHandler : HttpClientHandler
    {
        public UnsafeHttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (message, certificate, chain, sslPolicyErrors) => true;
        }
    }
}
