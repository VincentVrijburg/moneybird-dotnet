using Moneybird.Net.Extensions;
using Moneybird.Net.Entities.FinancialMutations;
using Moneybird.Net.Models.FinancialMutations;
using Xunit;

namespace Moneybird.Net.Tests.Extensions;

public class FinancialMutationsExtensionsTests
{
    [Fact]
    public void GetFilterString_FromFinancialMutationFilterOptions_NoFilters_Returns_EmptyString()
    {
        var options = new FinancialMutationFilterOptions();

        var actualString = options.GetFilterString();

        Assert.Equal(string.Empty, actualString);
    }

    [Fact]
    public void GetFilterString_FromFinancialMutationFilterOptions_PeriodOnly_Returns_CorrectString()
    {
        var options = new FinancialMutationFilterOptions
        {
            Period = "this_month"
        };

        const string expectedString = "filter=period:this_month";
        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromFinancialMutationFilterOptions_StateOnly_Returns_CorrectString()
    {
        var options = new FinancialMutationFilterOptions
        {
            State = new[] { FinancialMutationState.Unprocessed }
        };

        const string expectedString = "filter=state:unprocessed";
        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromFinancialMutationFilterOptions_StateAllOnly_Returns_CorrectString()
    {
        var options = new FinancialMutationFilterOptions
        {
            State = new[] { FinancialMutationState.All }
        };

        const string expectedString = "filter=state:all";
        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromFinancialMutationFilterOptions_StateAutoBookedOnly_Returns_CorrectString()
    {
        var options = new FinancialMutationFilterOptions
        {
            State = new[] { FinancialMutationState.AutoBooked }
        };

        const string expectedString = "filter=state:auto_booked";
        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromFinancialMutationFilterOptions_MutationTypeOnly_Returns_CorrectString()
    {
        var options = new FinancialMutationFilterOptions
        {
            MutationType = new[] { FinancialMutationType.Debit }
        };

        const string expectedString = "filter=mutation_type:debit";
        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromFinancialMutationFilterOptions_MutationTypeAllOnly_Returns_CorrectString()
    {
        var options = new FinancialMutationFilterOptions
        {
            MutationType = new[] { FinancialMutationType.All }
        };

        const string expectedString = "filter=mutation_type:all";
        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromFinancialMutationFilterOptions_FinancialAccountIdOnly_Returns_CorrectString()
    {
        var options = new FinancialMutationFilterOptions
        {
            FinancialAccountId = "492897320871921275"
        };

        const string expectedString = "filter=financial_account_id:492897320871921275";
        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromFinancialMutationFilterOptions_AmountFromOnly_Returns_CorrectString()
    {
        var options = new FinancialMutationFilterOptions
        {
            AmountFrom = 10.0
        };

        const string expectedString = "filter=amount_from:10";
        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromFinancialMutationFilterOptions_AmountToOnly_Returns_CorrectString()
    {
        var options = new FinancialMutationFilterOptions
        {
            AmountTo = 100.0
        };

        const string expectedString = "filter=amount_to:100";
        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }

    [Fact]
    public void GetFilterString_FromFinancialMutationFilterOptions_All_Returns_CorrectString()
    {
        var options = new FinancialMutationFilterOptions
        {
            Period = "this_month",
            State = new[] { FinancialMutationState.Unprocessed, FinancialMutationState.Processed },
            MutationType = new[] { FinancialMutationType.Debit, FinancialMutationType.Credit },
            FinancialAccountId = "492897320871921275",
            AmountFrom = 10.5,
            AmountTo = 99.99
        };

        const string expectedString =
            "filter=period:this_month," +
            "state:unprocessed|processed," +
            "mutation_type:debit|credit," +
            "financial_account_id:492897320871921275," +
            "amount_from:10.5," +
            "amount_to:99.99";

        var actualString = options.GetFilterString();

        Assert.Equal(expectedString, actualString);
    }
}
