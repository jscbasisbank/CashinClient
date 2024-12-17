using Basis.Service.Cashin.Api.Contract.Requests;
using Basis.Service.Cashin.Client;
using Basis.Service.Cashin.Client.Factory;
using Basis.Service.Cashin.Common.Extensions;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace Basis.Service.Cashin.Api.Client.Test
{
    public class UnitTestTransactionController
    {
        private const string _key = "";//გასაღები
        private const string _channelCode = "";//არხის კოდი
        private readonly ICashinApiClient _client;

        public UnitTestTransactionController()
        {
            _client = new CashinApiClient("შეცვალეთ ip მისამართით. მაგ: http://1.1.1.1:1111/", new CashinApiFactory());
        }


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCheckClient()
        {
            var request = new ClientCheckRequest()
            {
                IdentityNumber = "20001026744",
                IdentityType = Contract.Enums.IdentityTypeEnum.PersonalNumber,
                PayerVerifyData = new ClientPayerInfoRequest()
                {
                    IdentityNumber = "20001026744",
                    VerificationId = Guid.NewGuid().ToString(),
                }
            };

            var requestId = Guid.NewGuid();
            var token = CreateToken(request, requestId, _channelCode, _key);
            var headers = GenerateHeaders(_channelCode, requestId, token);
            var resp = _client.CheckAsync(request, headers).Result;
            var result = resp;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ClientNo > 0);

        }

        [Test]
        public void TestRegisterSuccess()
        {
            var transactionId = new Random().Next(100000, 100000000);

            var request = new TransactionRegisterRequest()
            {
                AccountId = 31200,
                Amount = 100,
                AmountCurrency = "GEL",
                ClientNo = 15170,
                PaymentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                PayerVerifyData = new PayerInfoRequest() { IdentityNumber = "01011021510", VerificationId = "1212" },
                ServiceCode = Contract.Enums.ServicesEnum.Deposits,
                Purpose = "0",
                TransactionId = $"Tran_{transactionId}",//Tran შეცვალეთ თქვენ ტრანზაქციის პრეფიქსით. სასურველია არხის კოდი.
            };


            var requestId = Guid.NewGuid();
            var token = CreateToken(request, requestId, _channelCode, _key);
            var headers = GenerateHeaders(_channelCode, requestId, token);



            var resp = _client.RegisterAsync(request, headers).Result;

            var result = resp;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.TransactionId > 0);
        }

        private IDictionary<string, string> GenerateHeaders(string channelCode, Guid requestId, string token)
        {

            IDictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("requestId", requestId.ToString());
            headers.Add("channelCode", channelCode);
            headers.Add("token", token);
            headers.Add("Content-Type", "application/json; charset=utf-8");
            headers.Add("Transfer-Encoding", "chunked");

            return headers;
        }

        private string CreateToken<T>(T bodyContent, Guid guid, string channenCode, string key) where T : class
        {
            var reqeustData = JsonConvert.SerializeObject(bodyContent, Formatting.None,
 new Newtonsoft.Json.Converters.StringEnumConverter());

            var beforeHash = $"{reqeustData.ToLower().ToMd5Hash()}{channenCode.ToLower()}{guid.ToString().ToLower()}{key}";
            var afterHashR = beforeHash.ToMd5Hash();

            return afterHashR;
        }
    }
}