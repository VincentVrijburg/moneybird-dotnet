using Moneybird.Net.Entities.PurchaseTransactions;
using Moneybird.Net.Extensions;
using Moneybird.Net.Models.PurchaseTransactions;
using Xunit;

namespace Moneybird.Net.Tests.Extensions;

public class PurchaseTransactionsExtensionsTests
{
    [Fact]
    public void GetFilterString_FromPurchaseTransactionFilterOptions_NoFilters_Returns_EmptyString()
    {
        var options = new PurchaseTransactionFilterOptions();

        const string expectedString = "";
        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromPurchaseTransactionFilterOptions_StateOnly_Returns_CorrectString()
    {
        var options = new PurchaseTransactionFilterOptions
        {
            State = new[] { PurchaseTransactionState.Open, PurchaseTransactionState.PendingPayment }
        };

        const string expectedString = "filter=state:open|pending_payment";
        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromPurchaseTransactionFilterOptions_PeriodOnly_Returns_CorrectString()
    {
        var options = new PurchaseTransactionFilterOptions
        {
            Period = "this_month"
        };

        const string expectedString = "filter=period:this_month";
        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromPurchaseTransactionFilterOptions_UnbatchedOnly_Returns_CorrectString()
    {
        var options = new PurchaseTransactionFilterOptions
        {
            Unbatched = true
        };

        const string expectedString = "filter=unbatched:true";
        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromPurchaseTransactionFilterOptions_SignableByUserOnly_Returns_CorrectString()
    {
        var options = new PurchaseTransactionFilterOptions
        {
            SignableByUser = true
        };

        const string expectedString = "filter=signable_by_user:true";
        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromPurchaseTransactionFilterOptions_All_Returns_CorrectString()
    {
        var options = new PurchaseTransactionFilterOptions
        {
            State = new[] { PurchaseTransactionState.AwaitingAuthorization, PurchaseTransactionState.PendingPayment },
            Period = "this_year",
            Unbatched = false,
            SignableByUser = true
        };

        const string expectedString = "filter=state:awaiting_authorization|pending_payment," +
                                      "period:this_year," +
                                      "unbatched:false," +
                                      "signable_by_user:true";
        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }
}
