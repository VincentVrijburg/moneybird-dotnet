using System.Linq;
using Moneybird.Net.Entities.Downloads;
using Moneybird.Net.Extensions;
using Moneybird.Net.Models.Downloads;
using Xunit;

namespace Moneybird.Net.Tests.Extensions;

public class DownloadsExtensionsTests
{
    [Fact]
    public void GetQueryParameters_FromDownloadFilterOptions_NoFilters_Returns_EmptyCollection()
    {
        var options = new DownloadFilterOptions();

        var actualParameters = options.GetQueryParameters().ToList();

        Assert.Empty(actualParameters);
    }

    [Fact]
    public void GetQueryParameters_FromDownloadFilterOptions_AllFilters_Returns_CorrectValues()
    {
        var options = new DownloadFilterOptions
        {
            DownloadType = DownloadType.ExportContacts,
            Downloaded = false,
            Failed = true
        };

        var actualParameters = options.GetQueryParameters().ToList();

        Assert.Equal(3, actualParameters.Count);
        Assert.Equal("download_type=export_contacts", actualParameters[0]);
        Assert.Equal("downloaded=false", actualParameters[1]);
        Assert.Equal("failed=true", actualParameters[2]);
    }
}
