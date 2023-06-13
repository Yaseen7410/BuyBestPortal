using System;
using System.Net.Http;

namespace Infrastructure.Common.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException()
        {
        }

        public ServiceException(string message) : base(message)
        {
        }

        public ServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ServiceException(string url, HttpResponseMessage response) : base($"Failed fetch of {url}")
        {
            try
            {
                ResponseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            catch
            {

            }
        }

        public string ResponseContent { get; private set; }
    }
}
