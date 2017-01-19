using La_Crosta_Insapore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace La_Crosta_Insapore.Data
{
    public interface IUserContext
    {
        int Register(UserModel user);
        UserModel Login(string email, string password);
        bool Update(UserModel user);
    }
}