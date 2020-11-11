using BESProject.YoutubeVideoTree.Business.Interfaces;
using BESProject.YoutubeVideoTree.DataAccess.Interfaces;
using BESProject.YoutubeVideoTree.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BESProject.YoutubeVideoTree.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal userDal;
        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }
        public bool CheckUserLogin(string userName, string password)
        {
            return userDal.CheckUserLogin(userName, password);
        }

        public void SignUp(User user)
        {
            userDal.SignUp(user);
        }
    }
}
