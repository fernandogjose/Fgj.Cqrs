using Bogus;
using Bogus.Extensions.Brazil;
using Fgj.Cqrs.IntegrationTest.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
            _webDriver.ButtonClick("btn-create");
            _webDriver.InputFill("name", faker.Person.FullName);
            _webDriver.InputFill("email", faker.Person.Email);
            _webDriver.SelectByValue("idType", "1");
            _webDriver.InputFill("cpfCnpj", faker.Person.Cpf());
            _webDriver.InputFill("avatar", faker.Person.Avatar);
            _webDriver.InputFill("address", faker.Person.Address.Street);
            _webDriver.ButtonClick("btn-save");

            Wait5Seconds();
            _webDriver.AlertClickOk();

            ValidateList();

            // TODO: Criar um assert encontrando o usuário criado na lista
        }
    }
}
