using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.Gherkin
{
    public class User
    {
        public readonly IPage Page;
        private readonly string _baseUrl;

        public User(IPage page, string baseUrl)
        {
            Page = page;
            _baseUrl = baseUrl;
        }

        public async Task<User> NavigatesToAsync(string relativePath)
        {
            await Page.GotoAsync(new Uri(new Uri(_baseUrl), relativePath).ToString());
            return this;
        }

        public async Task<User> ClicksOn(string selector)
        {
            await Page.ClickAsync(selector);
            return this;
        }
    }
}