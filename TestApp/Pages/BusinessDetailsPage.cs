using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace TestApp.Pages
{
    public class BusinessDetailsPage : PageObject
    {
        private readonly string _legalStatus = "Company";
        private readonly string _nameOfBusiness = $"Gábor Nyilas test company {DateTime.Today}";
        private readonly string _state = "Budapest";
        private readonly string _city = "Budapest";
        private readonly string _street = "Váci út";

        private readonly Random rnd = new Random();

        public BusinessDetailsPage(IPage page)
        {
            _page = page;
        }
        public async Task SetLegalStatus()
        {
            await _page.GetByLabel("What is your legal status?").ClickAsync();
            await _page.GetByRole(AriaRole.Option, new() { Name = "Company" }).ClickAsync();
        }

        public async Task SetNameOfBusiness()
        {
            await _page.Locator("#companyLegalNameOfBusiness").FillAsync(_nameOfBusiness);
        }
        
        public async Task SetIncorporationNumber()
        {
            await _page.GetByLabel("Incorporation number").FillAsync(rnd.Next(1,100).ToString());
        }

        public async Task SetIncorporationDate()
        {
            await _page.GetByPlaceholder("YYYY-MM-DD").ClickAsync();
            await _page.GetByText(DateTime.Today.Day.ToString(), new() { Exact = true }).ClickAsync();
        }

        public async Task SetState()
        {
            await _page.GetByLabel("State").FillAsync(_state);
        }

        public async Task SetZip()
        {
            await _page.GetByLabel("ZIP/Post code").FillAsync(rnd.Next(1001,9999).ToString());
        }

        public async Task SetCity()
        {
            await _page.GetByLabel("City").FillAsync(_city);
        }
        public async Task SetStreet()
        {
            await _page.GetByLabel("Street").FillAsync(_street);
        }
        public async Task SetHouseNumber()
        {
            await _page.GetByLabel("House number").FillAsync(rnd.Next(100, 999).ToString());
        }
        public async Task NextStep()
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = "Next step" }).ClickAsync();
        }
    }
}
