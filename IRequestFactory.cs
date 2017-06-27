using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArgosBenchmark
{
    public interface IRequestFactory
    {
        Task<Tuple<string, HttpResponseMessage>> SendRequestAsync(HttpClient Client);
    }
}
