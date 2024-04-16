using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Util;

namespace TestApp.Pages
{
    public class SignupPage : PageObject
    {
        public readonly string OriginCountry = "Hungary";
        private readonly IEnumerable<string> _allCountries;
        private IEnumerable<string> _selectedCountries;

        public string PageAddress
        {
            get { return _pageAddress; }
        }

        public SignupPage()
        {
            _pageAddress = "https://app.taxually.com/app/signup";
            _allCountries = new List<string>
            {
                "Czech Republic",
                "France",
                "Germany",
                "Italy",
                "Poland",
                "Spain",
                "EU - IOSS",
                "EU - OSS",
                "Non-Union OSS",
                "United Kingdom",
            };
        }



        public async Task SelectLocation(string country)
        {
            var element = _page.GetByRole(AriaRole.Combobox).GetByRole(AriaRole.Textbox);
            await element.ClickAsync();
            await element.FillAsync(country);
            await element.PressAsync("Enter");
        }

        private IEnumerable<T> Shuffle<T>(IEnumerable<T> source)
        {
            return source.OrderBy(x => Guid.NewGuid());
        }

        public async Task SelectTargetCountry(int numberOfCountries, MethodType methodType = MethodType.First)
        {
            int allCountiresCount = _allCountries.ToList().Count;
            int limit = numberOfCountries > allCountiresCount ? allCountiresCount : numberOfCountries;

            if (methodType == MethodType.First)
            {
                _selectedCountries = _allCountries.Take(limit);
            }
            else
            {
                _selectedCountries = Shuffle(_allCountries).Take(limit);
            }

                            
            _selectedCountries.ToList().ForEach(country =>
                _page.GetByRole(AriaRole.Button, new() { Name = country }).ClickAsync());
        }

        public async Task HelpMeGetVatNumbers()
        {
            _selectedCountries.ToList().ForEach(country => 
                _page.Locator("app-add-country-vatnumber div")
                .Filter(new() { HasText = $"{country} Help me get a VAT" })
                .GetByRole(AriaRole.Button)
                .ClickAsync());

            await _page.Locator("app-add-country-vatnumber div")
                .Filter(new() { HasText = $"{OriginCountry} Help me get a VAT" }).GetByRole(AriaRole.Button).ClickAsync();
        }

        public async Task NextStep()
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = "Next step" }).ClickAsync();
        }
    }
}
