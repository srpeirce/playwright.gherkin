using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;

namespace Playwright.Gherkin.XUnit
{
    [Trait("Category","UiTest")]
#if DEBUG
    [Collection("Stop parallell run")]
#endif
    
    // Todo: Change or remove this class? It's not so useful
    public abstract class PlayWrightUiTestsBase : IAsyncDisposable
    {
        protected readonly string BaseUrl = "https://localhost:5001";
        protected readonly IPlaywright Playwright;
        protected readonly IBrowser Browser;
        protected readonly IPage Page;
        protected readonly IBrowserContext Context;

        protected PlayWrightUiTestsBase()
        {
            BaseUrl = Environment.GetEnvironmentVariable("BaseUrl") ?? BaseUrl;
            Playwright = Microsoft.Playwright.Playwright.CreateAsync().GetAwaiter().GetResult();
            Browser = Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Devtools = false,
            }).GetAwaiter().GetResult();

            Context = Browser.NewContextAsync(new BrowserNewContextOptions()
            {
                // RecordVideoDir = "./recordings",
            }).GetAwaiter().GetResult();
            Page = Context.NewPageAsync().GetAwaiter().GetResult();
        }
        
        public async ValueTask  DisposeAsync()
        {
            await Context.CloseAsync();
            await Browser.CloseAsync();
            Playwright?.Dispose();
        }
    }
}