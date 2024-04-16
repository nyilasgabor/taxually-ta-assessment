using Microsoft.Playwright;
using System.Threading.Tasks;

namespace TestApp.Util
{
    public static class BrowserUtil
    {
        public static async Task<IPage> GetPageFromBrowser()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            return page;
        }
    }
}
