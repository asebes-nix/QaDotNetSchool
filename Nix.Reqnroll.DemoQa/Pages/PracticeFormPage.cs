using OpenQA.Selenium;

namespace Nix.Reqnroll.DemoQa.Pages;

internal class PracticeFormPage(IWebDriver driver) : BasePage(driver)
{
    private static readonly By FirstNameInput = By.Id("firstName");
    private static readonly By LastNameInput = By.Id("lastName");
    private static readonly By EmailInput = By.Id("userEmail");
    private static readonly By MobileInput = By.Id("userNumber");
    private static readonly By DateOfBirthInput = By.Id("dateOfBirthInput");
    private static readonly By SubjectsInput = By.Id("subjectsInput");
    private static readonly By CurrentAddressInput = By.Id("currentAddress");
    private static readonly By StateInput = By.CssSelector("#state input");
    private static readonly By CityInput = By.CssSelector("#city input");
    private static readonly By SubmitButton = By.Id("submit");

    private static By GenderLabel(string gender) =>
        By.XPath($"//div[@id='genterWrapper']//label[text()='{gender}']");

    private static By HobbyLabel(string hobby) =>
        By.XPath($"//div[@id='hobbiesWrapper']//label[text()='{hobby}']");

    private static By SubjectOption(string subject) =>
        By.XPath($"//div[contains(@class, 'subjects-auto-complete__option') and text()='{subject}']");

    private static By DropdownOption(string containerId, string value) =>
        By.XPath($"//div[@id='{containerId}']//div[contains(@class, 'option') and text()='{value}']");

    private static By ModalValue(string label) =>
        By.XPath($"//div[@class='modal-content']//td[text()='{label}']/following-sibling::td");

    public PracticeFormPage FillTextField(By field, string value)
    {
        IWebElement input = ScrollTo(field);
        input.Clear();
        input.SendKeys(value);
        return this;
    }

    public PracticeFormPage EnterFirstName(string value) => FillTextField(FirstNameInput, value);

    public PracticeFormPage EnterLastName(string value) => FillTextField(LastNameInput, value);

    public PracticeFormPage EnterEmail(string value) => FillTextField(EmailInput, value);

    public PracticeFormPage EnterMobile(string value) => FillTextField(MobileInput, value);

    public PracticeFormPage EnterCurrentAddress(string value) => FillTextField(CurrentAddressInput, value);

    public PracticeFormPage SelectGender(string gender)
    {
        Click(GenderLabel(gender));
        return this;
    }

    public PracticeFormPage EnterDateOfBirth(string date)
    {
        IWebElement input = ScrollTo(DateOfBirthInput);
        input.SendKeys(Keys.Control + "a");
        input.SendKeys(date);
        input.SendKeys(Keys.Enter);
        return this;
    }

    public PracticeFormPage AddSubject(string subject)
    {
        ScrollTo(SubjectsInput).SendKeys(subject);
        WaitForElement(SubjectOption(subject));
        Driver.FindElement(SubjectsInput).SendKeys(Keys.Enter);
        return this;
    }

    public PracticeFormPage SelectHobby(string hobby)
    {
        Click(HobbyLabel(hobby));
        return this;
    }

    public PracticeFormPage SelectState(string state)
    {
        ScrollTo(StateInput).SendKeys(state);
        Click(DropdownOption("state", state));
        return this;
    }

    public PracticeFormPage TypeCityAndPressEnter(string city)
    {
        ScrollTo(CityInput).SendKeys(city);
        WaitForElement(DropdownOption("city", city));
        Driver.FindElement(CityInput).SendKeys(Keys.Enter);
        return this;
    }

    public PracticeFormPage Submit()
    {
        Click(SubmitButton);
        return this;
    }

    public string GetModalValue(string label)
    {
        return WaitForElement(ModalValue(label)).Text;
    }
}