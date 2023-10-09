using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ImgesTelegramBot.Pinterest
{
    public class PinterestTest
    {
        private IWebDriver driver;

        private readonly By _signInButton = By.XPath("//*[@id=\"mweb-unauth-container\"]/div/div/div[1]/div/div[2]/div[2]/button/div/div");
        private readonly By _loginInputButton = By.XPath("//*[@id=\"email\"]");
        private readonly By _passwordInputButton = By.XPath("//*[@id=\"password\"]");
        private readonly By _confirmButton = By.XPath("//*[@id=\"__PWS_ROOT__\"]/div/div[1]/div[2]/div/div/div/div/div/div[4]/form/div[7]/button/div");
        private readonly By _searchButton = By.XPath("//*[@id=\"searchBoxContainer\"]/div/div/div[2]/input");
        private readonly By _filtresButton = By.XPath("//*[@id=\"__PWS_ROOT__\"]/div/div[1]/div/div[2]/div/div/div[2]/div/div/div/div[1]/div/div/div/div/div/div");
        
        public void Open()
        {

            driver = new OpenQA.Selenium.Edge.EdgeDriver();
            driver.Navigate().GoToUrl(@"https://ru.pinterest.com/");
            driver.Manage().Window.Maximize();
        }

        public void SignIn(string email, string password)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_signInButton));

            var signInElement = driver.FindElement(_signInButton);
            signInElement.Click();

            var loginElement = driver.FindElement(_loginInputButton);
            loginElement.SendKeys(email);

            var passwordElement = driver.FindElement(_passwordInputButton);
            passwordElement.SendKeys(password);

            var confirmButton = driver.FindElement(_confirmButton);
            confirmButton.Click();
        }

        public void Search(string text)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_searchButton));

            var searchElement = driver.FindElement(_searchButton);
            searchElement.SendKeys(text + "\n");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_filtresButton));
        }

        public void Close() => driver.Close();

        public string GetHtmlPage() => driver.PageSource;
    }
}
