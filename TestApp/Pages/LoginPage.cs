using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestApp.Pages
{
    public class LoginPage
    {

        private readonly string _pageAddress;
        private readonly string? _email = Environment.GetEnvironmentVariable("taxually_email", EnvironmentVariableTarget.User);
        private readonly string? _password = Environment.GetEnvironmentVariable("taxually_password", EnvironmentVariableTarget.User);
        private IPage _page;

        public LoginPage()
        {
            _pageAddress = "https://app.taxually.com/";
        }

        public async Task Login()
        {
            await EnterUsername();
            await EnterPassword();
            await ClickLoginButton();
        }

        public async Task Open()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            var context = await browser.NewContextAsync();

            _page = await context.NewPageAsync();
            await _page.GotoAsync(_pageAddress);
        }

        private async Task EnterUsername()
        {
            if (_email != null)
            {
                await _page.GetByRole(AriaRole.Textbox, new() { Name = "Email Address" }).FillAsync(_email);
            }
        }
        
        private async Task EnterPassword()
        {
            if (_password != null)
            {
                await _page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).FillAsync(_password);
            }
        }

        private async Task ClickLoginButton()
        {
            await _page.Locator("[type=submit]").ClickAsync();
        }
    }
}
