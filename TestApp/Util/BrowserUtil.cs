using Microsoft.Playwright;
using System.Threading.Tasks;

namespace TestApp.Util
{
    public static class BrowserUtil
    {
        private static IPlaywright _playwright;
        private static IBrowser _browser;
        public static async Task<IPage> GetPageFromBrowser()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            var context = await _browser.NewContextAsync();
            var page = await context.NewPageAsync();
            return page;
        }

        public static async Task Quit()
        {
            await _browser.CloseAsync();
        }
    }
}
