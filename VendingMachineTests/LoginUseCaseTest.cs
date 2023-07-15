using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.UseCases;
using Moq;
using System;
using Xunit;

namespace VendingMachineUnitTests
{
    public class LoginUseCaseTest
    {
        private Mock<IAuthenticationService> authenticationService = new Mock<IAuthenticationService>();
        private Mock<ILoginView> loginView = new Mock<ILoginView>();

        [Fact]
        public void HavingLoginUseCase_WhenPropertyIsLogin_ThenCompareItWithExpectedName()
        {
            string actual = "login";
            LoginUseCase loginUseCase = new LoginUseCase(authenticationService.Object, loginView.Object);

            Assert.Equal(loginUseCase.Name, actual);
        }

        [Fact]
        public void HavingLoginUseCase_WhenDescriptionIsSet_ThenCompareItWithExpectedDescription()
        {
            string actual = "Get access to administration section.";
            LoginUseCase loginUseCase = new LoginUseCase(authenticationService.Object, loginView.Object);

            Assert.Equal(loginUseCase.Description, actual);
        }

        [Fact]
        public void HavingLoginUseCase_WhenUserIsUnauthenticated_ThenCanExecuteReturnsTrue()
        {
            authenticationService.Setup(x => x.IsUserAuthenticated).Returns(false);
            LoginUseCase loginUseCase = new LoginUseCase(authenticationService.Object, loginView.Object);

            Assert.True(loginUseCase.CanExecute);
        }

        [Fact]
        public void HavingLoginUseCase_WhenExecuteMethodIsCalled_ThenAskForPasswordMethodIsCalled()
        {
            LoginUseCase loginUseCase = new LoginUseCase(authenticationService.Object, loginView.Object);

            loginUseCase.Execute();

            loginView.Verify(x => x.AskForPassword(), Times.Once);
        }

        [Fact]
        public void HavingLoginUseCase_WhenLoginViewIsNull_ThenTrowArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new LoginUseCase(authenticationService.Object, null));
        }

        [Fact]
        public void HavingLoginUseCase_WhenAuthenticationServiceIsNull_ThenTrowArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new LoginUseCase(null, loginView.Object));
        }
    }
}