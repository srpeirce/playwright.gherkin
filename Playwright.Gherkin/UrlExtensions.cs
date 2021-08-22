using System;

namespace Playwright.Gherkin
{
    public static class UrlExtensions
    {
        public static string GetAbsolutePath(this string url)
        {
            return new Uri(url).AbsolutePath;
        }
    }
}