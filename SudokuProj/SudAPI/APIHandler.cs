using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Json.Net;
using SudokuProj.Model;

namespace SudokuProj.SudAPI
{
    internal class APIHandler
    {
        
        public static async Task<SudukoLayout> GetSuduko()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "GuocSBDbYfvYzSwBxukOWGwJL4vtFAQQupoqLVSK");
            SudukoLayout user = null;

            HttpResponseMessage response = await client.GetAsync("v1/sudokugenerate?difficulty=medium&width=3&height=3");
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                responseString = responseString.Trim();
                responseString = responseString.Replace("null", "-1"); // Won't accept 'null' as value so replacing with -1

                user = JsonNet.Deserialize<SudukoLayout>(responseString);
            }
            Thread.Sleep(3000);
            return user;
        }
    }
}
