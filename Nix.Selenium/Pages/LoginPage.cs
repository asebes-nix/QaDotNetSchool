using OpenQA.Selenium;

namespace Nix.Selenium.Pages;

internal class LoginPage(IWebDriver webDriver)
{
    private IWebElement UsernameInput => webDriver.FindElement(By.Id("user-name"));

    public LoginPage EnterUsername(string username)
    {
        UsernameInput.SendKeys(username);
        return this;
    }

    private IWebElement PasswordInput => webDriver.FindElement(By.Id("password"));

    public LoginPage EnterPassword(string password)
    {
        PasswordInput.SendKeys(password);
        return this;
    }

    private IWebElement LoginButton => webDriver.FindElement(By.Id("login-button"));

    public LoginPage ClickLoginButton()
    {
        LoginButton.Click();
        return this;
    }

    private IWebElement LoginLogo => webDriver.FindElement(By.ClassName("login_logo"));

    public bool IsLoginLogoDisplayed()
    {
        return LoginLogo.Displayed;
    }

    private IWebElement ErrorMessage => webDriver.FindElement(By.CssSelector("[data-test='error']"));

    public string GetErrorMessage()
    {
        return ErrorMessage.Text;
    }

    private IWebElement ErrorCloseButton => webDriver.FindElement(By.CssSelector("[data-test='error-button']"));

    public LoginPage CloseErrorMessage()
    {
        ErrorCloseButton.Click();
        return this;
    }
}