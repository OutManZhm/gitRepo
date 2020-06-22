using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
namespace Commen
{
    public class DapperDBContextOptions : IOptions<DapperDBContextOptions>
    {
        public string Configuration { get; set; }

        DapperDBContextOptions IOptions<DapperDBContextOptions>.Value
        {
            get { return this; }
        }
    }

}
