using System;

namespace Moneybird.Net.Tests
{
    public class CommonTestBase
    {
        protected static string ClientId = "dc7b2233b635a8c71c7dc2d42442c1ff";
        protected static string ClientSecret = "244efae6eeae13a5d25ae6e290834fa8c7c6b0af4366dfdba1a37fba82c33372";
        
        protected static string RequestToken = "9a3ed1a1b37882f47f81e7131be292414ca51fdd39055a4c7c9de654efac8212";

        protected static string RedirectUriOutOfBand = "urn:ietf:wg:oauth:2.0:oob";
        protected static string RedirectUriEndUser = "https://bird.example.com/oauthcallback";
    }
}