﻿namespace iQuest.VendingMachine.Interfaces
{
    public interface IAuthenticationService
    {
        public bool IsUserAuthenticated { get; }
        public void Login(string password);
        public void Logout();

    }
}
