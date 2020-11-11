using System.Threading.Tasks;

namespace Acme.Core.OperationHandlers
{
    public interface IOperationHandler<in TRequest, TResponse>
    {
        Task<TResponse> ProcessAsync(TRequest request);
    }
}
