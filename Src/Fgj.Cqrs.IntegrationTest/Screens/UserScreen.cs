using Bogus;
using Bogus.Extensions.Brazil;
using Fgj.Cqrs.IntegrationTest.Extensions;
using OpenQA.Selenium;
using System;
using Xunit;

namespace Fgj.Cqrs.IntegrationTest.Screens
{
    public class UserScreen : BaseScreen
    {
        public void ShowScreen()
        {
            string url = $"{_configuration.GetSection("Selenium:Urls:Dashboard").Value}/users";
            _webDriver.LoadPage(TimeSpan.FromSeconds(60), url);
            _webDriver.Manage().Window.Maximize();
        }

        public void ValidateList()
        {
            Wait5Seconds();
            string table = _webDriver.GetHtml(By.CssSelector("table"));

            Assert.True(!string.IsNullOrEmpty(table));
        }

        public void Create()
        {
            Faker faker = new Faker();
            _webDriver.ButtonClick(By.LinkText("Create"));
            _webDriver.InputFill("name", faker.Person.FullName);
            _webDriver.InputFill("email", faker.Person.Email);
            _webDriver.SelectByValue("idType", "1");
            _webDriver.InputFill("cpfCnpj", faker.Person.Cpf());
            _webDriver.InputFill("avatar", faker.Person.Avatar);
            _webDriver.InputFill("address", faker.Person.Address.Street);
            _webDriver.ButtonClick(By.Id("btn-save"));
        }
    }
}
