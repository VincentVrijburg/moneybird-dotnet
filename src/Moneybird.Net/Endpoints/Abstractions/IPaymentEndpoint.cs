using System.Threading.Tasks;
using Moneybird.Net.Entities.Payments;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IPaymentEndpoint : IGetEndpoint<Payment>
    {
    }
}
