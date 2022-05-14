using Jose;
using Newtonsoft.Json;
using System.Text;

namespace AutoRepairShop.Api.Authentication
{
    public static class Auth
    {
        public static string key;
        private static byte[] KeyBytes => Encoding.UTF8.GetBytes(key);
        private const JwsAlgorithm algorithm = JwsAlgorithm.HS256;

        /// <summary>
        /// Criar token e guardar nele um objeto do tipo payload
        /// </summary>
        /// <param name="payload">Payload do token</param>
        /// <returns>Token</returns>
        public static string EncodeToken(Payload payload)
        {
                payload.ExpirationDate = DateTime.Now.AddHours(8);
            return JWT.Encode(payload, KeyBytes, algorithm);
        }

        public static string EncodeBaseToken(BasePayload basePayload)
        {
            return JWT.Encode(basePayload, KeyBytes, algorithm);
        }

        /// <summary>
        /// Decode token
        /// </summary>
        /// <param name="token">Token</param>
        /// <returns>Payload do token</returns>
        public static Payload DecodeToken(string token)
        {
            try
            {
                token = token.Replace("Bearer ", "");
                return JsonConvert.DeserializeObject<Payload>(JWT.Decode(token, KeyBytes, algorithm));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static BasePayload DecodeBaseToken(string token)
        {
            try
            {
                token = token.Replace("Bearer ", "");
                return JsonConvert.DeserializeObject<BasePayload>(JWT.Decode(token, KeyBytes, algorithm));
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// retorna o usuario logado na sessao
        /// </summary>
        /// <param name="request">request atributo da controller</param>
        /// <returns></returns>
        public static Payload UserLogedIn(HttpRequest request)
            => DecodeToken(request.Headers["Authorization"]);

        public static BasePayload UserBaseLogedIn(HttpRequest request)
            => DecodeBaseToken(request.Headers["Authorization"]);
    }
}
