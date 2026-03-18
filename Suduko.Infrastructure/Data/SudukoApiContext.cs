using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Suduko.Model;
using Suduko.Model.Entities;
using Json.Net;
using Suduko.Model.Interface;

namespace Suduko.Infrastructure.Data
{
    public class SudukoApiContext : ISudukoServiceAPI
    {
        static string api_key = "";

        public async Task<List<string>> CreateAsync()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", api_key);
            SudukoLayout suduko = null;

            HttpResponseMessage response = await client.GetAsync("v1/sudokugenerate?difficulty=medium&width=3&height=3");
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                responseString = responseString.Trim();
                responseString = responseString.Replace("null", "-1"); // Won't accept 'null' as value so replacing with -1

                suduko = JsonNet.Deserialize<SudukoLayout>(responseString);
            }
            Thread.Sleep(3000);

            if (suduko != null)
            {
                List<string> result = new List<string>();
                Func<int[], List<string>> res_func = (x) =>
                {
                    List<string> res = new List<string>();
                    foreach (var item in x)
                    {
                        res.Add(item.ToString());
                    }
                    return res;
                };

                foreach (var row in suduko.Puzzle)
                {
                    result.AddRange(res_func(row));
                }

                return result;
            }

            return null;
        }

        public Task UpdateAsync(SudukoLayout suduko)
        {
            throw new NotImplementedException();
        }
    }
}