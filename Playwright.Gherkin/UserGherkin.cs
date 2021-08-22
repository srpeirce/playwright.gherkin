using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.Gherkin
{
    public static class UserGherkin
    {
        public static async Task<User> GivenTheUserIsOnUrl(IPage playwrightPage, string baseUrl, string relativePath = "")
        {
            var user = new User(playwrightPage, baseUrl);
            return await user.NavigatesToAsync(relativePath);
        }

        public static async Task<User> WhenTheUserGoesToUrl(IPage playwrightPage, string baseUrl, string relativePath = "")
        {
            var user = new User(playwrightPage, baseUrl);
            return await user.NavigatesToAsync(relativePath);
        }
    }
}