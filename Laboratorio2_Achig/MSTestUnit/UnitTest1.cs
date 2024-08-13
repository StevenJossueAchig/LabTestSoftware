using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V125.Page;

namespace MSTestUnit
{
    [TestClass]
    public class UnitTest1
    {
        By googleSearchBar = By.Id("APjFqb");
        By googleButtonClick = By.Name("btnK");
        //By resultGoogleSearch = By.Id("_HFy7ZqKZCquOwbkP9p_24QE_31");
        By resultGoogleSearch = By.Id("rcnt");

        int tiempoEspera = 3000;

        private readonly IWebDriver driver;

        public UnitTest1()
        {
            driver = new ChromeDriver();
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        //[TestMethod]
        //public void TestPageGoogle()
        //{
        //    IWebDriver driver = new ChromeDriver();

        //    driver.Manage().Window.Maximize();

        //    driver.Navigate().GoToUrl("https://www.google.com");

        //    Thread.Sleep(tiempoEspera);

        //    driver.FindElement(googleSearchBar).SendKeys("Visual Studio Code");

        //    Thread.Sleep(tiempoEspera);

        //    driver.FindElement(googleButtonClick).Click();

        //    Thread.Sleep(tiempoEspera);

        //    var resultadoBusqueda = driver.FindElement(resultGoogleSearch);

        //    Assert.IsNotNull(resultadoBusqueda);

        //    driver.Quit();

        //}

        [TestMethod]
        public void Create_Get_ReturnCreateView()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            Thread.Sleep(tiempoEspera);

            driver.Navigate().GoToUrl("https://localhost:7002/Cliente/Create");

            Thread.Sleep(tiempoEspera);

            driver.FindElement(By.Name("Cedula")).SendKeys("1780456842");
        }
    }
}