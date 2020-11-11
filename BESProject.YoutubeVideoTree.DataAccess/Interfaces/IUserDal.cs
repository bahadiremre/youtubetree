using BESProject.YoutubeVideoTree.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BESProject.YoutubeVideoTree.DataAccess.Interfaces
{
    public interface IUserDal
    {
        bool CheckUserLogin(string userName, string password);

        void SignUp(User user);
    }
}
