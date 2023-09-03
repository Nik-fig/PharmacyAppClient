using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyAppClient.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net;

namespace PharmacyAppClient.utils.api
{
    public class DrugsApi
    {
        private static DrugsApi instance;
        private Uri url;

        private HttpClient httpClient;

        private DrugsApi()
        {
            httpClient = new HttpClient();
            url = new Uri("http://localhost:5015");
        }

        public async Task<List<Drug>> GetAllDrugsAsync()
        {
            var response = await httpClient.GetAsync(url + "api/drugs/all");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var drugs = await response.Content.ReadFromJsonAsync<List<Drug>>();
                return drugs;
            }
            else
            {
                Console.WriteLine("Error");
                return null;
            }
        }

        public async Task<HttpStatusCode> DeleteDrugAsync(Drug drug)
        {
            var response = await httpClient.DeleteAsync(url + $"api/drugs/{drug.Id}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return HttpStatusCode.OK;
            }
            else
            {
                return response.StatusCode;
            }
        }

        public static DrugsApi getInstance()
        {
            if (instance == null)
                instance = new DrugsApi();
            return instance;
        }
    }
}
