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

        public SudukoClass()
        {
            CreateSuduko();
        }

        private async void CreateSuduko()
        {
            SudukoApiContext sudukoApi = new SudukoApiContext();
            SudukoRows = await sudukoApi.CreateAsync();
            Thread.Sleep(3000);
        }
    }
}
