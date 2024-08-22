using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V125.Page;
using OpenQA.Selenium.Support.UI;
using System;
using Npgsql;


namespace MSTestUnit
{
    [TestClass]
    public class UnitTest1
    {
        /*By googleSearchBar = By.Id("APjFqb");
        By googleButtonClick = By.Name("btnK");
        //By resultGoogleSearch = By.Id("_HFy7ZqKZCquOwbkP9p_24QE_31");
        By resultGoogleSearch = By.Id("rcnt");*/

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

        #region Pruebas de Crear Cliente
        By ButtonCreate = By.ClassName("btn-success");

        [TestMethod]
        public void Create_Get_ReturnCreateView()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            Thread.Sleep(tiempoEspera);

            driver.Navigate().GoToUrl("https://localhost:7002/Cliente/Create");

            Thread.Sleep(tiempoEspera);

            // Selecciona la provincia "01" (Azuay)
            SelectElement selectProvincia = new SelectElement(driver.FindElement(By.Name("Provincia")));
            selectProvincia.SelectByValue("01");

            // Resto del código para llenar el formulario
            driver.FindElement(By.Name("Apellidos")).SendKeys("Achig Toapanta");
            driver.FindElement(By.Name("Nombres")).SendKeys("Steven Jossue");
            driver.FindElement(By.Name("FechaNacimiento")).SendKeys("21/11/2001");
            driver.FindElement(By.Name("Mail")).SendKeys("stevenjossue5@gmail.com");
            driver.FindElement(By.Name("Telefono")).SendKeys("0998476747");
            driver.FindElement(By.Name("Direccion")).SendKeys("Colonche y Chilibulo");
            driver.FindElement(By.Id("saldo")).SendKeys("0");

            IWebElement checkbox = driver.FindElement(By.Name("Estado"));
            if (!checkbox.Selected)
            {
                checkbox.Click();
            }

            Thread.Sleep(tiempoEspera);

            driver.FindElement(ButtonCreate).Click();

            Thread.Sleep(tiempoEspera);

            // Verifica que el registro se creó en la base de datos
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dbproductos";
            string query = "SELECT COUNT(*) FROM cliente WHERE mail = 'stevenjossue5@gmail.com'";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                Assert.IsTrue(count > 0, "El cliente no fue creado en la base de datos.");
            }
        }

        #endregion

        #region Pruebas de Actualizar Cliente

        By ButtonUpdate = By.ClassName("btn-info");

        [TestMethod]
        public void Update_Get_ReturnUpdateView()
        {
            // Inicializar el driver de Selenium
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            Thread.Sleep(tiempoEspera);

            // Navegar a la página de clientes
            driver.Navigate().GoToUrl("https://localhost:7002/Cliente");

            Thread.Sleep(tiempoEspera);

            // Encuentra y haz clic en el botón de edición del cliente específico (por ejemplo, con ID 16)
            IWebElement editButton = driver.FindElement(By.XPath("//a[contains(@href, '/Cliente/Edit/16')]"));
            editButton.Click();

            Thread.Sleep(tiempoEspera);

            // Actualizar la dirección
            driver.FindElement(By.Name("Direccion")).Clear();
            driver.FindElement(By.Name("Direccion")).SendKeys("Mariscal Sucre y Michelena");

            // Actualizar el estado
            IWebElement checkbox = driver.FindElement(By.Name("Estado"));
            if (!checkbox.Selected) // Si el checkbox no está seleccionado, lo seleccionamos
            {
                checkbox.Click();
            }

            Thread.Sleep(tiempoEspera);

            // Guardar los cambios
            driver.FindElement(ButtonCreate).Click();

            Thread.Sleep(tiempoEspera);

            // Verificar que la dirección se actualizó correctamente en la base de datos
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dbproductos";
            string query = "SELECT direccion FROM cliente WHERE mail = 'raul.vargas@hotmail.com'";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                connection.Open();
                string direccionActualizada = command.ExecuteScalar().ToString();
                Assert.AreEqual("Mariscal Sucre y Michelena", direccionActualizada, "La dirección no fue actualizada correctamente en la base de datos.");
            }

        }
        #endregion

        #region Pruebas de Eliminar Cliente

        //By ButtonDelete = By.ClassName("btn-danger");

        [TestMethod]
        public void Delete_Get_ReturnDeleteView()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            Thread.Sleep(tiempoEspera);

            // Navegar a la página de clientes
            driver.Navigate().GoToUrl("https://localhost:7002/Cliente");

            Thread.Sleep(tiempoEspera);

            // Encuentra y haz clic en el botón de eliminación del cliente con ID 15
            IWebElement deleteButton = driver.FindElement(By.XPath("//a[contains(@href, '/Cliente/Delete/61')]"));
            deleteButton.Click();

            Thread.Sleep(tiempoEspera);

            // Encuentra y haz clic en el botón para confirmar la eliminación
            By ButtonDelete = By.ClassName("btn-danger");
            driver.FindElement(ButtonDelete).Click();

            Thread.Sleep(tiempoEspera);

            // Verificar que el cliente haya sido eliminado en la base de datos
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dbproductos";
            string query = "SELECT COUNT(*) FROM cliente WHERE mail = 'stevenjossue5@gmail.com'";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                connection.Open();
                long count = (long)command.ExecuteScalar(); // Cambiar a long
                Assert.AreEqual(0, count, "El cliente no fue eliminado correctamente de la base de datos.");
            }

        }
        #endregion

        #region Pruebas de Ver Cliente

        [TestMethod]
        public void View_Get_ReturnGetView()
        {
            // Configurar el WebDriver
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            Thread.Sleep(tiempoEspera);

            // Navegar a la página principal
            driver.Navigate().GoToUrl("https://localhost:7002/");

            Thread.Sleep(tiempoEspera);

            // Hacer clic en el enlace para ver los clientes
            IWebElement ViewButton = driver.FindElement(By.XPath("//a[contains(@href, '/Cliente')]"));
            ViewButton.Click();

            Thread.Sleep(tiempoEspera);

            // Verificar que haya registros en la base de datos
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dbproductos";
            string query = "SELECT COUNT(*) FROM cliente";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                connection.Open();
                long count = (long)command.ExecuteScalar(); // Cambiar a long
                Assert.IsTrue(count > 0, "No hay registros en la base de datos. La prueba falló.");
            }

        }

        #endregion
    }
}

