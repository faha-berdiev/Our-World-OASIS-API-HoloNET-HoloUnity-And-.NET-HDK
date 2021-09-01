using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Enums;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Models.Common
{
    public class Response<T> where T : new()
    {
        public string Message { get; set; }
        public ResponseStatus Status { get; set; }
        public T Payload { get; set; }

        public Response()
        {
            Message = "Ok";
            Status = ResponseStatus.Successfully;
            Payload = new T();
        }
    }
}