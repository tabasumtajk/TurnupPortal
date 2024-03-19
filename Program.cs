using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//Open the web browser  /chrome 

IWebDriver driver =  new ChromeDriver ();
//Lauch the Turnup portal url
driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
driver.Manage().Window.Maximize();
//identify the User name and ener in to  the textbox

IWebElement UsernameTextbox = driver.FindElement(By.Id("UserName"));
UsernameTextbox.SendKeys("Hari");
//Identify the password and enter in to text box
IWebElement PasswordTextbox = driver.FindElement(By.Id("Password"));
PasswordTextbox.SendKeys("123123");
//Identify the login button and click
IWebElement Loginbutton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
Loginbutton.Click();
//After Login to check user successfull login is done.
IWebElement SuccessfulLogin = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
if(SuccessfulLogin.Text == "Hello hari!")
{
    Console.WriteLine("Login successfull");
}
else
{
    Console.WriteLine("Login Failure");
}

// Create time and material for turn up portal//
IWebElement Admindropdown = driver.FindElement(By.XPath("//*[contains(text(),'Administration')]"));
Admindropdown.Click();

IWebElement TimeandMaterial = driver.FindElement(By.XPath("//*[contains(text(),'Time & Materials')]"));
TimeandMaterial.Click();

IWebElement CreateNewButtonclick = driver.FindElement(By.XPath("//*[contains(text(),'Create New')]"));
CreateNewButtonclick.Click();
IWebElement ClickMaterialDropdown = driver.FindElement(By.XPath("//span[text()='Material']"));
ClickMaterialDropdown.Click();
IWebElement ClicktimeselectionDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
ClicktimeselectionDropdown.Click();
IWebElement CodeTextbox = driver.FindElement(By.Id("Code"));
CodeTextbox.SendKeys("Testingt&m");
IWebElement DescriptionTextbox = driver.FindElement(By.Id("Description"));
DescriptionTextbox.SendKeys("test time&material ");
IWebElement PriceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
PriceTextbox.SendKeys("25");
IWebElement SaveButtonClick = driver.FindElement(By.Id("SaveButton"));
SaveButtonClick.Click();
Thread.Sleep(3000);
IWebElement GotolastPageButtonClick = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
GotolastPageButtonClick.Click();


IWebElement NewRecordCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
if (NewRecordCode.Text.Equals("Testingt&m"))
    {
    Console.WriteLine("New time and material record created");
}
else
{
    Console.WriteLine("New time and material record is not created");

}
Thread.Sleep(3000);
IWebElement GotolastPagetoeditClick = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
GotolastPagetoeditClick.Click();

//Edit time and material ///
IWebElement EditButtonclick = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
EditButtonclick.Click();
Thread.Sleep(3000);
IWebElement EditMaterialDropdown = driver.FindElement(By.XPath("//span[text()='Material']"));
EditMaterialDropdown.Click();
IWebElement EdittimeselectionDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span"));
EdittimeselectionDropdown.Click();
IWebElement EditCodeTextbox = driver.FindElement(By.Id("Code"));
EditCodeTextbox.Clear();
EditCodeTextbox.SendKeys("Testingt&m");
IWebElement EditDescriptionTextbox = driver.FindElement(By.Id("Description"));
EditDescriptionTextbox.Clear();
EditDescriptionTextbox.SendKeys("testing time&material edit");
IWebElement ClearPriceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
ClearPriceTextbox.Click();

IWebElement EditPriceTextbox = driver.FindElement(By.Id("Price"));
EditPriceTextbox.Clear();
ClearPriceTextbox.Click();
EditPriceTextbox.SendKeys("220");
IWebElement EditSaveButtonClick = driver.FindElement(By.Id("SaveButton"));
EditSaveButtonClick.Click();
Thread.Sleep(5000);
IWebElement GotoEditlastPageButtonClick = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
GotoEditlastPageButtonClick.Click();
Thread.Sleep(3000);
IWebElement GotoEditedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
if (GotoEditedDescription.Text.Equals("testing time&material edit")){
    Console.WriteLine("time and material edited successfully");

}
else
{
    Console.WriteLine("time and material not edited successfully");
}

//Delete time and material record--//

IWebElement DeleteButtonClk = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
DeleteButtonClk.Click();
Thread.Sleep(3000);
IAlert DeleteAlert = driver.SwitchTo().Alert();
String alerttxt = DeleteAlert.Text;
Console.WriteLine("Text from alert box---" + alerttxt);
DeleteAlert.Accept();
