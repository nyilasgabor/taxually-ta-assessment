using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using TestApp.Pages;
using TestApp.Util;

namespace TestApp;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task TestTaxtuallyApp()
    {
        IPage page = await BrowserUtil.GetPageFromBrowser();

        LoginPage loginPage = new LoginPage();
        await loginPage.Open(page);
        await loginPage.Login();

        SignupPage signupPage = new SignupPage();

        await Expect(page).ToHaveURLAsync(new Regex(signupPage.PageAddress));

        await signupPage.Open(page);
        await signupPage.SelectLocation("Hungary");
    }
}