using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.Common.Configuration
{
    public class DaftraSettings
    {
        public string Subdomain { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;

        public string BaseUrl => $"https://{Subdomain}.daftra.com/api2/";
        public string BaseUrlV2Entity => $"https://{Subdomain}.daftra.com/v2/api/entity/";

    }
}
