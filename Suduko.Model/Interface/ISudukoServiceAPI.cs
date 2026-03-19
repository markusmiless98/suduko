using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suduko.Model.Entities;

namespace Suduko.Model.Interface
{
    public interface ISudukoServiceAPI
    {
        Task<List<string>> CreateAsync(); // SudukoLayout service
        //Task<SudukoLayout> GetAllAsync();
        //Task DeleteAsync();

        Task<List<string>> GetAsync();

        Task UpdateAsync(SudukoLayout suduko);
    }
}
