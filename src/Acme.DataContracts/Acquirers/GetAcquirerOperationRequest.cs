namespace Acme.DataContracts.Acquirers
{
    public sealed class GetAcquirerOperationRequest
    {
        public GetAcquirerOperationRequest(int id, bool forceRetrievingFromDatabase)
        {
            Id = id;
            ForceRetrievingFromDatabase = forceRetrievingFromDatabase;
        }

        public int Id { get; }

        public bool ForceRetrievingFromDatabase { get; }
    }
}