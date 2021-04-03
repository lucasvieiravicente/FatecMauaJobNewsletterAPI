using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FatecMauaJobNewsletter.Domains.Utils
{
    public static class ContentUtils
    {
        private const string _jsonContentType = "application/json";

        public static StringContent FormatToJsonContent<T>(this T contentObject)
        {
            if (contentObject is null)
                return null;

            string content = JsonConvert.SerializeObject(contentObject);
            var stringContent = new StringContent(content, Encoding.UTF8, _jsonContentType);
            return stringContent;
        }

        public static async Task<T> FormatContentTo<T>(this HttpContent content)
        {
            string json = await content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(json))
                throw new Exception("Não há nenhum contéudo para converter");

            try
            {
                return json.FormatJsonTo<T>();
            }
            catch(Exception ex)
            {
                string message = "Não foi possível converter o arquivo json" + ex.Message;
                throw new Exception(message);
            }
        }

        public static T FormatJsonTo<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
