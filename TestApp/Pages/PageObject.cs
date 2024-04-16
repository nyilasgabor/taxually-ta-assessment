using Microsoft.Playwright;
using System.Threading.Tasks;

namespace TestApp.Pages
{
    public class PageObject
    {
        protected string _pageAddress;
        protected IPage _page;

        public async Task Open(IPage page)
        {
            _page = page;
            await _page.GotoAsync(_pageAddress);
        }
    }
}
