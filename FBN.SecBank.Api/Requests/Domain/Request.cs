using System.ComponentModel.DataAnnotations;

namespace FBN.SecBank.Api.Requests.Domain
{
    public class Request
    {
        [Key]
        public Guid ReqId { get; set; }
        public string RequestType { get; set; }
        public DateTime RequestDate { get; set; }
        public bool RequestStatus { get; set; }
    }
}
