using System.Threading.Tasks;
using Acme.Core.OperationHandlers.AcquirerOperationHandlers;
using Acme.DataContracts.Acquirers;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Api.Controllers
{
    [Route("acquirers")]
    public class AcquirerController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, [FromQuery] bool forceRetrievingFromDatabase, [FromServices] IGetAcquirerOperationHandler operation)
        {
            var response = await operation.ProcessAsync(new GetAcquirerOperationRequest(id, forceRetrievingFromDatabase)).ConfigureAwait(false);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}