namespace Acme.DataContracts.Merchants
{
    public sealed class GetMerchantOperationRequest
    {
        public GetMerchantOperationRequest(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}