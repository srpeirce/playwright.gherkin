[![NuGet version (Playwright.Gherkin)](https://img.shields.io/nuget/v/Playwright.Gherkin.svg?style=flat-square)](https://www.nuget.org/packages/Playwright.Gherkin/)
[![Nuget](https://img.shields.io/nuget/dt/Playwright.Gherkin?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Playwright.Gherkin/)
[![.NET](https://github.com/srpeirce/playwright.gherkin/actions/workflows/dotnet.yml/badge.svg)](https://github.com/srpeirce/playwright.gherkin/actions/workflows/dotnet.yml)
[![MIT License](https://img.shields.io/github/license/dotnet/aspnetcore?color=%230b0&style=flat-square)](https://github.com/srpeirce/playwright.gherkin/blob/main/LICENSE)

# Playwright.Gherkin

An opinionated library for writing Playwright tests in [Gherkin Syntax](https://cucumber.io/docs/gherkin/reference/).

## Why?

- We like the Given/When/Then syntax for automated browser tests, and want something simple/lightweight.


## Getting Started

Install Nuget Package into test project. For XUnit 
```
dotnet install Playwright.Gherkin.XUnit
```

If you just want the syntax without the baseclass:
```
dotnet install Playwright.Gherkin
```

Currently inheriting from a base class in XUnit, but you don't have to do this. Will probably tweak this soon.


AboutUsPageTests.cs
```csharp
public class AboutUsPageTests : PlayWrightUiTestsBase
{
    [Fact]
    public async Task PreRenderOnServer()
    {
        await WhenTheUserGoesToUrl(Page, BaseUrl, AboutUsPage.Path)
            .Then(user => user.IsOnTheAboutUsPage());
    }

    [Fact]
    public async Task RenderOnClient()
    {
        await GivenTheUserIsOnUrl(Page, BaseUrl, IndexPage.Path)
            .When(user => user.ClicksOn(Footer.AboutUsLink))
            .Then(user => user.IsOnTheAboutUsPage());
    }
}
```

Footer.cs
```csharp
public static class Footer
{
    public const string AboutUsLink = "data-test-id=footer-link-aboutus";
}
```

```csharp
public static class AboutUsPage
{
    public const string Path = "/about-us";

    public static async Task<User> IsOnTheAboutUsPage(this User user)
    {
        await user.Page.WaitForSelectorAsync($"data-test-id=page-aboutus");
        
        var title = await user.Page.TitleAsync();
        title.Should().Be("About Us | Powered 4 TV");

        user.Page.Url.GetAbsolutePath().Should().Be(Path);
        return user;
    }
}

```

## Documentation

Use intellisense and look at the code for now :-)

## Contributions

Currently in a very early version/stage of this project.

Please raise issues and feel free to submit PRs (happy to discuss in an issue first to avoid wasted effort).


## Examples

Todo...