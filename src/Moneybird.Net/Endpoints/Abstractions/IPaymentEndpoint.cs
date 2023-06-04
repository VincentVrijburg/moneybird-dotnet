using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.Payments;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IPaymentEndpoint : IGetEndpoint<Payment>
    {
    }
}
