using MonkeyFinder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MonkeyFinder.Service
{
    public class MonkeyService
    {
        HttpClient httpClient;

        public MonkeyService() {
            httpClient = new HttpClient();
        }

        List<Monkey> monkeyList = [];
        public async Task<List<Monkey>> GetMonkeys()
        {
            if (monkeyList?.Count > 0) return monkeyList;

            var url = "https://montemagno.com/monkeys.json";
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
            }

            //In Case We don't have any internet, then from local Json File
            //using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
            //using var reader = new StreamReader(stream);
            //var content = await reader.ReadToEndAsync();
            //monkeyList = JsonSerializer.Deserialize<List<Monkey>>(content);

            return monkeyList;
        }
    }
}
