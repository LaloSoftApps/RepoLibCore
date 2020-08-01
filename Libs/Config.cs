using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Libs
{
    public class Config
    {
        public string JsonFile { get; set; }

        public IConfiguration Read()
        {
            if (JsonFile == null)
            {
                JsonFile = $"{Environment.CurrentDirectory}\\AppConfig.json";
            }

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(JsonFile, true, true)
                .Build();

            return config;
        } 
    }
}
