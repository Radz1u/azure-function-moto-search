using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Radz1u
{
    public static class OlxAdCheck
    {
        [FunctionName("OlxAdCheck")]
        public static void Run([TimerTrigger("0 0 4 * * *")]TimerInfo myTimer, ILogger log)
        {
            var reader =new  OlxAdsReader();
        }
    }
}
