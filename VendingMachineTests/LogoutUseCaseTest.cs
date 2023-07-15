using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;
using System;
using Xunit;

namespace VendingMachineUnitTests
{
    public class LogoutUseCaseTest
    {
        private Mock<IAuthenticationService> authenticationService = new Mock<IAuthenticationService>();

        [Fact]
        public void HavingLogoutUseCase_WhenPropertyIsLogout_ThenCompareItWithExpectedName()
        {
            string actual = "logout";
            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService.Object);

            Assert.Equal(logoutUseCase.Name, actual);
        }

        [Fact]
        public void HavingLogoutUseCase_WhenDescriptionIsSet_ThenCompareItWithExpectedDescription()
        {
            string actual = "Restrict access to administration section.";
            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService.Object);

            Assert.Equal(logoutUseCase.Description, actual);
        }

        [Fact]
        public void HavingLogoutUseCase_WhenUserIsAuthenticated_ThenCanExecuteReturnsTrue()
        {
            authenticationService.Setup(x => x.IsUserAuthenticated).Returns(true);
            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService.Object);

            Assert.True(logoutUseCase.CanExecute);
        }

        [Fact]
        public void HavingLogoutUseCase_WhenAuthenticationServiceIsNull_ThenThrowArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new LogoutUseCase(null));
        }

        [Fact]
        public void HavingLogoutUseCase_WhenExecuteMethodIsCalled_ThenLogoutMethodIsCalled()
        {
            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService.Object);

            logoutUseCase.Execute();

            authenticationService.Verify(x => x.Logout(), Times.Once);
        }
    }
}