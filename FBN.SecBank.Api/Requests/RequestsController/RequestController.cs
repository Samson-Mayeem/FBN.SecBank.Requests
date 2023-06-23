using FBN.SecBank.Api.Requests.Domain;
using FBN.SecBank.Api.Requests.RequestService;
using Microsoft.AspNetCore.Mvc;

namespace FBN.SecBank.Api.Requests.RequestsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestServices _requestServices;

        public RequestController(IRequestServices requestServices)
        {
            _requestServices = requestServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllReq()
        {
            var requests = await _requestServices.GetAllRequestsAsync();
            return Ok(requests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReqById(Guid id)
        {
            var request = await _requestServices.GetRequestById(id);
            if (request == null)
                return NotFound();

            return Ok(request);
        }

        [HttpPost]
        public async Task<IActionResult> AddReq(List<Request> requests)
        {
            await _requestServices.AddAccount(requests);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReq(Guid id, Request request)
        {
            try
            {
                if (id != request.ReqId)
                    return BadRequest();

                var existingRequest = await _requestServices.GetRequestById(id);
                if (existingRequest == null)
                    return NotFound();

                existingRequest.RequestType = request.RequestType; // Update the desired properties accordingly
                existingRequest.RequestDate = request.RequestDate;
                existingRequest.RequestStatus = request.RequestStatus;
                // ...

                await _requestServices.UpdateRequestAsync(existingRequest);
                return Ok(existingRequest); // Return the updated request object in the response  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500); // Handle any exceptions with an appropriate status code
            }
        }


       



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReq(Guid id)
        {
            var deletedRequest = await _requestServices.DeleteRequestAsync(id);
            if (deletedRequest == null)
                return NotFound();

            return Ok(deletedRequest);
        }
    }
}
    
