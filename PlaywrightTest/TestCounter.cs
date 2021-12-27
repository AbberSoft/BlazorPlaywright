using Xunit;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTest;

public class TestCounter
{

    private const string ApplicationUrl = "https://localhost:5001";

    [Fact]
    public async Task ClickingOnCounterIncrements()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        
        var page = await browser.NewPageAsync(new BrowserNewPageOptions
        {
            IgnoreHTTPSErrors = true
        });
        
        await page.GotoAsync(ApplicationUrl + "/counter");
        await page.ClickAsync(".increment-button");
        await page.WaitForSelectorAsync("text=Current count: 1");
    }
}