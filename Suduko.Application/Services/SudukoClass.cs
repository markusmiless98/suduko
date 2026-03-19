using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suduko.Infrastructure.Data;

namespace Suduko.Application.Services
{
    public class SudukoClass
    {
        public List<string> SudukoRows { get; set; }
        private SudukoApiContext suduko_api = new SudukoApiContext();

        public SudukoClass()
        {
            CreateSuduko();
        }

        private async void CreateSuduko()
        {
            SudukoRows = await suduko_api.GetAsync();
        }

        public async Task<List<string>> GetSuduko()
        {
            if (SudukoRows == null)
            {
                CreateSuduko();
                Thread.Sleep(3000);
            }
            Thread.Sleep(1000);
            if (SudukoRows != null)
            {
                return SudukoRows;
            }
            return null;
        }

        public async Task<List<string>> WriteSuduko()
        {
            int i = 0;
            int row = 0;

            List<string> items = await GetSuduko();
            Thread.Sleep(2000);

            List<string> result = new List<string>();

            string res_now = "";

            foreach (var item in items)
            {
                string cur = "";

                if (item != "-1")
                {
                    cur = "[" + item + "]";
                }
                else
                {
                    cur = "[ ]";
                }
                if (i % 3 == 0)
                {
                    res_now += " | ";
                }
                res_now += cur;
                if (i >= 8)
                {
                    i = 0;
                    row++;
                    result.Add(res_now);
                    res_now = "";
                    if (row % 3 == 0)
                    {
                        result.Add("-------------------------------------------");
                    }
                    result.Add("");
                }
                else
                {
                    i++;
                }
            }
            return result;
        }
    }
}
