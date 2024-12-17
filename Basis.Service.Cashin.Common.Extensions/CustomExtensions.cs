
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace Basis.Service.Cashin.Common.Extensions
{
    public static class CustomExtensions
    {
        public static string ToJson<T>(this T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string ToMasked(this string accountIban)
        {
            if (string.IsNullOrEmpty(accountIban))
                throw new ArgumentNullException(nameof(accountIban));
            return
                $"{accountIban.Substring(0, 4)}{new String('*', accountIban.Length - 10)}{accountIban.Substring(accountIban.Length - 6, 6)}";
        }

        public static string ToMd5Hash(this string input)
        {
            MD5 hash = MD5.Create();
            byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static long LogRequestResponseRowId(this HttpRequestMessage request)
        {
            try
            {
                return Convert.ToInt64(request.Headers.GetValues("LogRequestResponseId").FirstOrDefault());
            }
            catch
            {
                return 0;
            }
        }
    }
}
