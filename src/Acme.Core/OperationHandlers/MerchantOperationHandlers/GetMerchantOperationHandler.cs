using System.Threading.Tasks;
using Acme.Core.Repositories;
using Acme.DataContracts.Merchants;

namespace Acme.Core.OperationHandlers.MerchantOperationHandlers
{
    public class GetMerchantOperationHandler : IGetMerchantOperationHandler
    {
        private readonly IMerchantRepository _merchantRepository;

        public GetMerchantOperationHandler(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        public async Task<GetMerchantOperationOperationResponse> ProcessAsync(GetMerchantOperationRequest operationRequest)
        {
            var merchant = await this._merchantRepository.GetByIdAsync(operationRequest.Id);
            if (merchant == null)
            {
                return null;
            }

            return new GetMerchantOperationOperationResponse
            {
                Data = new MerchantResponseData
                {
                    Id = merchant.Id,
                    FantasyName = merchant.FantasyName
                }
            };
        }
    }
}
