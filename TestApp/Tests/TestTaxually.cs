using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using TestApp.Pages;

namespace TestApp;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task TestTaxtuallyApp()
    {
        LoginPage loginPage = new LoginPage();
        await loginPage.Open();
        await loginPage.Login();


    }
}