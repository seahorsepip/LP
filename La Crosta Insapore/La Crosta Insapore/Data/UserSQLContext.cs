using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using La_Crosta_Insapore.Models;

namespace La_Crosta_Insapore.Data
{
    public class UserSQLContext : IUserContext
    {
        public UserModel Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public int Register(UserModel user)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}