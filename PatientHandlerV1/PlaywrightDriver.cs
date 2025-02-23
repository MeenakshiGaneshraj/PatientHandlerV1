using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientHandlerV1
{
    public class PlaywrightDriver : IDisposable
    {
        private readonly Task<IAPIRequestContext?>? _requestContext;
        public PlaywrightDriver()
        {
            _requestContext = CreateApiContext();
        }
        public IAPIRequestContext? ApiRequestContext => _requestContext?.GetAwaiter().GetResult();
        public void Dispose()
        {
            _requestContext?.Dispose();
        }
        private async Task<IAPIRequestContext?> CreateApiContext()
        {
            var playwright = await Playwright.CreateAsync();
            return await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = "https://ab0f9c14-3401-4db2-ba5a-851976c4155f.mock.pstmn.io",
                IgnoreHTTPSErrors = true
           
            });
        }
    }
}