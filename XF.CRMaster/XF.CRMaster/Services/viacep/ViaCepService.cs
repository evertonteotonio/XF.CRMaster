//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XF.CRMaster.Services.viacep
{
    class ViaCepService
    {
        string url = "http://viacep.com.br/ws/";
        HttpClient _client;


        public ViaCepService()
        {
            _client = new HttpClient();
        }


        public async Task<ViaCepDTO> GetAddressByAsync(string cep)
        {


            try
            {
                var uri = new Uri(string.Format(url + cep + "/json", string.Empty));
                var json = await _client.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<ViaCepDTO>(json);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public ViaCepDTO GetAddressBy(string cep)
        {


            var task = Task.Run(async () => { return await GetAddressByAsync(cep); });
            task.Wait();

            if (task.IsCompleted)
                return task.Result;

            if (task.IsFaulted)
                return null;


            return null;


        }

    }
}
