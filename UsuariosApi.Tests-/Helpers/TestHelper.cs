using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApi.Tests_.Helpers
{
    public class TestHelper
    {
        //método para criar um client (requisição) para a API
        public static HttpClient CreateClient()
        {
            return new WebApplicationFactory<Program>().CreateClient();
        }

        //método para serializar os dados em JSON
        public static StringContent CreateContent(Object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj),
                            Encoding.UTF8, "application/json");
        }
    }
}
