using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Administrations
{
    /// <summary>
    /// Administration access types.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AdministrationAccess
    {
        [JsonStringEnumMemberName("accountant_company")]
        AccountantCompany,
        [JsonStringEnumMemberName("user")]
        User
    }
}