using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorldBank.Repository
{
    public interface IJsonData
    {
        Task<string> JsonData(int page = 1);
    }

}
