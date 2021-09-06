using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Enums;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Factory.ConfigurationProvider;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Models.Common;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Models.Entity;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Services.EntityMigrator
{
    public sealed class EntityMigrator<T> : IEntityMigrator<T> where T : new()
    {
        private readonly IConfigurationProvider _configuration;

        public EntityMigrator(IConfigurationProvider configuration)
        {
            _configuration = configuration;
        }

        public async Task<Response<T>> GetEntity(string entityContent)
        {
            var response = new Response<T>();
            try
            {
                var key = await _configuration.GetKey("EncryptSecretKey");
                var decryptContent = await DecryptString(key, entityContent);
                response.Payload = JsonConvert.DeserializeObject<T>(decryptContent);
                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = ResponseStatus.Failed;
                return response;
            }
        }

        public async Task<Response<EntityContent>> GetEntityContent(T entity)
        {
            var response = new Response<EntityContent>();
            try
            {
                var key = await _configuration.GetKey("EncryptSecretKey");
                var entityContent = new EntityContent
                {
                    Content = await EncryptString(key, JsonConvert.SerializeObject(entity))
                };
                response.Payload = entityContent;
                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = ResponseStatus.Failed;
                return response;
            }
        }

        private async Task<string> EncryptString(string key, string plainText)
        {
            var iv = new byte[16];

            using var aes = Aes.Create();
            if (aes == null) return null;
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            await using var memoryStream = new MemoryStream();
            await using var cryptoStream = new CryptoStream((Stream) memoryStream, encryptor, CryptoStreamMode.Write);
            await using var streamWriter = new StreamWriter((Stream) cryptoStream);
            await streamWriter.WriteAsync(plainText);

            var array = memoryStream.ToArray();
            return Convert.ToBase64String(array);
        }

        private async Task<string> DecryptString(string key, string cipherText)
        {
            var iv = new byte[16];
            var buffer = Convert.FromBase64String(cipherText);

            using var aes = Aes.Create();
            if (aes == null) return string.Empty;
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            await using var memoryStream = new MemoryStream(buffer);
            await using var cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read);
            using var streamReader = new StreamReader((Stream) cryptoStream);
            return await streamReader.ReadToEndAsync();
        }
    }
}