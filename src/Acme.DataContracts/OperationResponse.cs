namespace Acme.DataContracts
{
    public class OperationResponse { }

    public class OperationResponse<TData> : OperationResponse
    {
        public TData Data{ get; set; }
    }
}