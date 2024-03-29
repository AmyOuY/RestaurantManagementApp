﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using RMUI;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace XUnitTest
{
    public class TestClientProvider
    {
        public HttpClient Client { get; private set; }

        public TestClientProvider()
        {
            var server = new TestServer(WebHost.CreateDefaultBuilder()
                    .UseStartup<Startup>());
            Client = server.CreateClient();
        }
    }
}
