﻿using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool IsUserAuthenticated { get; private set; }

        public void Login(string password)
        {
            if (password == "supercalifragilisticexpialidocious")
                IsUserAuthenticated = true;
            else
                throw new InvalidPasswordException();
        }

        public void Logout()
        {
            IsUserAuthenticated = false;
        }
    }
}