﻿namespace ShopCenter.MVC.Contracts
{
    public interface IAuthenticateService
    {
        Task<bool> Authenticate(string email,string password);
        Task<bool> Register(string firstName,string lastName,string userName,string password);
        Task Logout(); 
    }
}
