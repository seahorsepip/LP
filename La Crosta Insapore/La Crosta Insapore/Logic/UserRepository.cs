using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using La_Crosta_Insapore.Data;
using La_Crosta_Insapore.Models;

namespace La_Crosta_Insapore.Logic
{
    public class UserRepository
    {
        IUserContext context;

        public UserRepository(IUserContext context)
        {
            this.context = context;
        }

        public UserModel Register(UserModel user)
        {
            user.Id = context.Register(user);
            if (user.Id == 0)
            {
                throw new Exception();
            }
            return user;
        }

        public void Login(string email, string password)
        {
            UserModel user = context.Login(email, password);
            if (user == null)
            {
                throw new Exception();
            }
        }
    }
}