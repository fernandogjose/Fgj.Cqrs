using Bogus;
using Fgj.Cqrs.Domain.Commands;
using System;
using System.Linq;
using Xunit;

namespace Fgj.Cqrs.UnitTest._3_Domain.Commands
{
    public class UserCreateCommandTest
    {
        private readonly Faker _faker;

        public UserCreateCommandTest()
        {
            _faker = new Faker();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void Should_Show_Error_When_IdProfile_Invalid(int idProfile)
        {
            UserCreateCommand userCreateCommand = new UserCreateCommand(idProfile, Guid.NewGuid().ToString(), _faker.Person.FullName, _faker.Person.Email);

            userCreateCommand.Validate();

            Assert.True(!userCreateCommand.IsValid());
            Assert.True(userCreateCommand.Errors?.FirstOrDefault(x => x == "Profile is required") != null);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_Show_Error_When_Name_Null_Or_Empty(string name)
        {
            UserCreateCommand userCreateCommand = new UserCreateCommand(1, Guid.NewGuid().ToString(), name, _faker.Person.Email);

            userCreateCommand.Validate();

            Assert.True(!userCreateCommand.IsValid());
            Assert.True(userCreateCommand.Errors?.FirstOrDefault(x => x == "Name is required") != null);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_Show_Error_When_Email_Null_Or_Empty(string email)
        {
            UserCreateCommand userCreateCommand = new UserCreateCommand(1, Guid.NewGuid().ToString(), _faker.Person.FullName, email);

            userCreateCommand.Validate();

            Assert.True(!userCreateCommand.IsValid());
            Assert.True(userCreateCommand.Errors?.FirstOrDefault(x => x == "E-mail is required") != null);
        }
    }
}
