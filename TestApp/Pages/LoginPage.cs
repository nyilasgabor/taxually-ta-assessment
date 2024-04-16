using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace TestApp.Pages
{
    public class LoginPage: PageObject
    {
        private readonly string? _email = Environment.GetEnvironmentVariable("taxually_email", EnvironmentVariableTarget.User);
        private readonly string? _password = Environment.GetEnvironmentVariable("taxually_password", EnvironmentVariableTarget.User);

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
