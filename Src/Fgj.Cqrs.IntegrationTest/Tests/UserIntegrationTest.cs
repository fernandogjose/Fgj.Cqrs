using Fgj.Cqrs.IntegrationTest.Screens;
using Fgj.Cqrs.IntegrationTest.Utils;
using System;
using Xunit;

namespace Fgj.Cqrs.IntegrationTest.Tests
{
    public class UserIntegrationTest
    {
        private UserScreen UserScreen;

        [Fact]
        public void Should_List_User()
        {
            try
            {
                UserScreen = new UserScreen();
                UserScreen.ShowScreen();
                UserScreen.ValidateList();
            }
            catch (Exception ex)
            {
                throw ErrorUtil.GetError(ex);
            }
            finally
            {
                UserScreen.CloseScreen();
            }
        }

        [Fact]
        public void Should_Add_User()
        {
            try
            {
                UserScreen = new UserScreen();
                UserScreen.ShowScreen();
                UserScreen.ValidateList();
                UserScreen.Create();
            }
            catch (Exception ex)
            {
                throw ErrorUtil.GetError(ex);
            }
            finally
            {
                UserScreen.CloseScreen();
            }
        }
    }
}
