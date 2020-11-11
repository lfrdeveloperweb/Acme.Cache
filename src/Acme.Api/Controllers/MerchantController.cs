using System.Threading.Tasks;
using Acme.Core.OperationHandlers.MerchantOperationHandlers;
using Acme.DataContracts.Merchants;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Api.Controllers
{
    [Route("merchants")]
    public class MerchantController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id, [FromServices] IGetMerchantOperationHandler operation)
        {
            var response = await operation.ProcessAsync(new GetMerchantOperationRequest(id)).ConfigureAwait(false);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
