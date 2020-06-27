using Bogus;
using Fgj.Cqrs.Domain.Commands;
using System.Linq;
using Xunit;

namespace Fgj.Cqrs.UnitTest._3_Domain.Commands
{
    public class UserAddCommandTest
    {
        private readonly Faker _faker;

        public UserAddCommandTest()
        {
            _faker = new Faker();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void Should_Show_Error_When_IdProfile_Invalid(int idProfile)
        {
            UserAddCommand userAddCommand = new UserAddCommand(idProfile, _faker.Person.FullName, _faker.Person.Email);

            userAddCommand.Validate();

            Assert.True(!userAddCommand.IsValid());
            Assert.True(userAddCommand.Errors?.FirstOrDefault(x => x == "Profile is required") != null);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_Show_Error_When_Name_Null_Or_Empty(string name)
        {
            UserAddCommand userAddCommand = new UserAddCommand(1, name, _faker.Person.Email);

            userAddCommand.Validate();

            Assert.True(!userAddCommand.IsValid());
            Assert.True(userAddCommand.Errors?.FirstOrDefault(x => x == "Name is required") != null);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_Show_Error_When_Email_Null_Or_Empty(string email)
        {
            UserAddCommand userAddCommand = new UserAddCommand(1, _faker.Person.FullName, email);

            userAddCommand.Validate();

            Assert.True(!userAddCommand.IsValid());
            Assert.True(userAddCommand.Errors?.FirstOrDefault(x => x == "E-mail is required") != null);
        }
    }
}
