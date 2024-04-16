using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace TestApp.Pages
{
    public class SignupPage: PageObject
    {
        public string PageAddress
        {
            get { return _pageAddress; }
        }

        public SignupPage()
        {
            _pageAddress = "https://app.taxually.com/app/signup";
        }

        public async Task SelectLocation(string country)
        {
            await _page.GetByRole(AriaRole.Combobox).GetByRole(AriaRole.Textbox).ClickAsync();
            await _page.GetByRole(AriaRole.Combobox).GetByRole(AriaRole.Textbox).FillAsync(country);
        }
    }
}
