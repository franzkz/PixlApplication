using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using TestApplication.Models;

namespace TestApplication.Services
{
    public class PixlService
    {
        readonly string requestUri = "http://api.pixlpark.com/oauth/requesttoken";
        readonly string accessUri = "http://api.pixlpark.com/oauth/accesstoken";
        readonly string refreshUri = "http://api.pixlpark.com/oauth/refreshtoken";
        readonly string ordersUri = "http://api.pixlpark.com/orders";

        readonly string publicKey = "dd6a71e250ae4a67a87d381cd5b69ec0";
        readonly string privateKey = "e8dc9c6a83b949c096ddb611e52bef29";

        private static PixlService instance;
        private PixlService() { }

        public static PixlService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PixlService();
                }
                return instance;
            }
        }

        public RequestTokenModel requestToken { get; set; }
        public AccessTokenModel accessToken { get; set; }

        public async Task<RequestTokenModel> GetRequestTokenAsync()
        {

            using (HttpClient httpClient = new HttpClient())
            {
                requestToken = JsonConvert.DeserializeObject<RequestTokenModel>(await httpClient.GetStringAsync(requestUri));
                return requestToken;
            }
        }

        public async Task<AccessTokenModel> GetAccessTokenAsync(string requestToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var fullUri = accessUri + "?oauth_token=" + requestToken + "&grant_type=api&username=" + publicKey +
                              "&password=" + GetPassShaOne(requestToken, privateKey);

                return JsonConvert.DeserializeObject<AccessTokenModel>(await httpClient.GetStringAsync(fullUri));
            }
        }

        public async Task<AccessTokenModel> RefreshTokenAsync(string refreshToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var fullUri = refreshUri + "?refreshToken=" + refreshToken;

                return JsonConvert.DeserializeObject<AccessTokenModel>(await httpClient.GetStringAsync(fullUri));
            }
        }

        public async Task<string> GetOrders(string accessToken, int skip, int take)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var fullUri = ordersUri + "?oauth_token=" + accessToken + "&skip=" + skip + "&take=" + take;
                return await httpClient.GetStringAsync(fullUri);
            }
        }

        private string GetPassShaOne(string requestToken, string privateKey)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(requestToken + privateKey);

            var shaObj = SHA1.Create();
            var hashArr = shaObj.ComputeHash(bytes);
            return HexStringFromBytes(hashArr);
        }

        private string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}