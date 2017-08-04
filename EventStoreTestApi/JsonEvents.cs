using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventStoreTestApi
{
    public class JsonEvents
    {
        public static string RequestedEvent = @"
            {
              ""MerchantId"": 200890,
              ""BusinessId"": 201779,
              ""ChannelId"": 212253,
              ""Amount"": {
                ""Value"": 8.95,
                ""CurrencyIso3Code"": ""EUR""
              },
              ""Card"": {
                ""VaultId"": ""57ac25a6-a3f2-440e-a86e-169627b32f21"",
                ""Fingerprint"": ""a925258c8bf39e0faa64f59ce5dfsfsd78f4983fcda61552722bcdsfdsfsfs"",
                ""Scheme"": ""MasterCard"",
                ""MaskedNumber"": """",
                ""ExpiryMonth"": """",
                ""ExpiryYear"": """",
                ""Name"": """",
                ""Bin"": """",
                ""Category"": ""Consumer"",
                ""Type"": ""Debit"",
                ""ProductId"": ""TCS"",
                ""IssuerName"": ""MASTERCARD LON"",
                ""IssuerCountryIso2Code"": ""GB"",
                ""ProductType"": ""STANDARD"",
                ""BillingAddress"": {
                  ""Line1"": """",
                  ""Line2"": """",
                  ""TownCity"": """",
                  ""State"": """",
                  ""Postcode"": """",
                  ""Country"": """"
                },
                ""Phone"": {}
              },
              ""BillingDescriptor"": {
                ""Name"": ""Test                 "",
                ""City"": ""London       ""
              },
              ""Capture"": true,
              ""CaptureOn"": ""2017-08-03T17:02:30.4471629Z"",
              ""Is3DS"": false,
              ""RequestedOn"": ""2017-08-03T17:02:30.4471629Z"",
              ""AttemptN3d"": false,
              ""SkipRiskCheck"": true,
              ""Customer"": {
                ""Id"": ""cc6c0c56-bc91-4e46-9480-d22e06c9f146"",
                ""Email"": """",
                ""IPAddress"": ""9"",
                ""CardId"": ""57ac25a6-a3f2-440e-a86e-169627bb4221""
              },
              ""MerchantReference"": ""2318616"",
              ""Metadata"": {
                ""username"": ""dsfjdslkjflksdjlfjsdlkjflksfdsfsdfds"",
                ""password"": ""dsfjsdlkfjlksdjflkjsdlfsdjlfks"",
                ""provider"": ""dsfjdslkfjls""
              },
              ""Items"": [],
              ""Destinations"": [],
              ""Shipping"": {
                ""Address"": {},
                ""Phone"": {}
              },
              ""Type"": ""REGULAR"",
              ""Source"": {
                ""Type"": ""Card""
              },
              ""ChargeId"": ""74d0b512-6f6a-444d-9eee-da59ff444780"",
              ""CorrelationId"": ""faf44885-cc3a-4c33-bbbb-b449003ddb36""
            }
        ";

        public static string AuthorisedJson = @"
            {
              ""Transactions"": [
                {
                  ""Id"": ""74d0b512-6f6a-444d-9ddd-da59ff444780"",
                  ""Value"": 8.95,
                  ""AcquirerId"": 23,
                  ""AcquirerCredentialId"": 111111,
                  ""AcquirerTransactionId"": ""879789789798798789FHJ908098098"",
                  ""AcquirerReferenceNumber"": ""809809809809"",
                  ""AuthorisationCode"": ""11761221234"",
                  ""ResponseCode"": ""10000"",
                  ""ResponseSummary"": ""Approved"",
                  ""ResponseDetails"": ""Approved"",
                  ""AvsCheck"": ""S"",
                  ""CvvCheck"": ""U"",
                  ""AcquirerMetadata"": {},
                  ""ProcessedOn"": ""2017-08-03T17:02:29.6972012Z"",
                  ""ProcessingTime"": 0.0
                }
              ],
              ""ChargeId"": ""74d0b512-6f6a-444d-9ddd-da59ff444780"",
              ""CorrelationId"": ""faf44885-cc3a-4c33-9f94-b449003ddb36""
            }
        ";
    }
}