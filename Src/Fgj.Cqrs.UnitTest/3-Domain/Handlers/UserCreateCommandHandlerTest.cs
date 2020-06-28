using Bogus;
using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Handlers;
using Fgj.Cqrs.Domain.Interfaces.SqlServerRepositories;
using Fgj.Cqrs.Domain.Interfaces.Validations;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Fgj.Cqrs.UnitTest._3_Domain.Handlers
{
    public class UserCreateCommandHandlerTest
    {
        private readonly Faker _faker;
        private readonly UserCreateCommandHandler _userCreateCommandHandler;
        private readonly Mock<IUserSqlServerRepository> _userSqlServerRepositoryMock;
        private readonly Mock<IUserValidation> _userValidationMock;

        public UserCreateCommandHandlerTest()
        {
            // Faker
            _faker = new Faker();

            // Mock
            _userValidationMock = new Mock<IUserValidation>();
            _userSqlServerRepositoryMock = new Mock<IUserSqlServerRepository>();

            // CommandHandler
            _userCreateCommandHandler = new UserCreateCommandHandler(_userSqlServerRepositoryMock.Object, _userValidationMock.Object);
        }

        [Fact]
        public async Task Should_Create_User_When_All_Parameters_Success()
        {
            UserCreateCommand userCreateCommand = new UserCreateCommand(1, Guid.NewGuid().ToString(), _faker.Person.FullName, _faker.Person.Email);
            _userValidationMock.Setup(r => r.IsDuplicateName(It.IsAny<string>(), It.IsAny<string>())).Returns(Tuple.Create(false, "Name already exist"));
            _userSqlServerRepositoryMock.Setup(r => r.Create(It.IsAny<UserCreateCommand>())).Returns(_faker.Random.Number(1, 100));

            ResponseCommand response = await _userCreateCommandHandler.Handle(userCreateCommand, CancellationToken.None).ConfigureAwait(true);

            Assert.True(response.Success);
            Assert.True((int)response.Object > 0);
        }

        [Fact]
        public async Task Should_Show_Error_When_Some_Parameters_Is_Invalid()
        {
            UserCreateCommand userCreateCommand = new UserCreateCommand(1, Guid.NewGuid().ToString(), _faker.Person.FullName, _faker.Person.Email);
            userCreateCommand.AddError("Meu erro para testar o UnitTest");

            ResponseCommand response = await _userCreateCommandHandler.Handle(userCreateCommand, CancellationToken.None).ConfigureAwait(true);

            Assert.True(!response.Success);
            Assert.True(((List<string>)response.Object).Count > 0);
            Assert.True(((List<string>)response.Object).Find(x => x == "Meu erro para testar o UnitTest") != null);
        }

        [Fact]
        public async Task Should_Show_Error_When_Duplicate_Name()
        {
            UserCreateCommand userCreateCommand = new UserCreateCommand(1, Guid.NewGuid().ToString(), _faker.Person.FullName, _faker.Person.Email);
            _userValidationMock.Setup(r => r.IsDuplicateName(It.IsAny<string>(), It.IsAny<string>())).Returns(Tuple.Create(true, "Name already exist"));

            ResponseCommand response = await _userCreateCommandHandler.Handle(userCreateCommand, CancellationToken.None).ConfigureAwait(true);

            Assert.True(!response.Success);
            Assert.True(((List<string>)response.Object).Count > 0);
            Assert.True(((List<string>)response.Object).Find(x => x == "Name already exist") != null);
        }
    }
}
