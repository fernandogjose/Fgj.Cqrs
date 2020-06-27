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
    public class UserAddCommandHandlerTest
    {
        private readonly Faker _faker;
        private readonly UserAddCommandHandler _userAddCommandHandler;
        private readonly Mock<IUserSqlServerRepository> _userSqlServerRepositoryMock;
        private readonly Mock<IUserValidation> _userValidationMock;

        public UserAddCommandHandlerTest()
        {
            // Faker
            _faker = new Faker();

            // Mock
            _userValidationMock = new Mock<IUserValidation>();
            _userSqlServerRepositoryMock = new Mock<IUserSqlServerRepository>();

            // CommandHandler
            _userAddCommandHandler = new UserAddCommandHandler(_userSqlServerRepositoryMock.Object, _userValidationMock.Object);
        }

        [Fact]
        public async Task Should_Add_User_When_All_Parameters_Success()
        {
            UserAddCommand userAddCommand = new UserAddCommand(1, _faker.Person.FullName, _faker.Person.Email);
            _userValidationMock.Setup(r => r.IsDuplicateName(It.IsAny<int>(), It.IsAny<string>())).Returns(Tuple.Create(false, "Name already exist"));
            _userSqlServerRepositoryMock.Setup(r => r.Add(It.IsAny<UserAddCommand>())).Returns(_faker.Random.Number(1, 100));            

            ResponseCommand response = await _userAddCommandHandler.Handle(userAddCommand, CancellationToken.None).ConfigureAwait(true);

            Assert.True(response.Success);
            Assert.True((int)response.Object > 0);
        }

        [Fact]
        public async Task Should_Show_Error_When_Some_Parameters_Is_Invalid()
        {
            UserAddCommand userAddCommand = new UserAddCommand(1, _faker.Person.FullName, _faker.Person.Email);
            userAddCommand.AddError("Meu erro para testar o UnitTest");

            ResponseCommand response = await _userAddCommandHandler.Handle(userAddCommand, CancellationToken.None).ConfigureAwait(true);

            Assert.True(!response.Success);
            Assert.True(((List<string>)response.Object).Count > 0);
            Assert.True(((List<string>)response.Object).Find(x => x == "Meu erro para testar o UnitTest") != null);
        }

        [Fact]
        public async Task Should_Show_Error_When_Duplicate_Name()
        {
            UserAddCommand userAddCommand = new UserAddCommand(1, _faker.Person.FullName, _faker.Person.Email);
            _userValidationMock.Setup(r => r.IsDuplicateName(It.IsAny<int>(), It.IsAny<string>())).Returns(Tuple.Create(true, "Name already exist"));

            ResponseCommand response = await _userAddCommandHandler.Handle(userAddCommand, CancellationToken.None).ConfigureAwait(true);

            Assert.True(!response.Success);
            Assert.True(((List<string>)response.Object).Count > 0);
            Assert.True(((List<string>)response.Object).Find(x => x == "Name already exist") != null);
        }
    }
}
