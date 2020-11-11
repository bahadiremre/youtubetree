using BESProject.YoutubeVideoTree.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BESProject.YoutubeVideoTree.Business.Interfaces
{
    public interface IUserService
    {
        bool CheckUserLogin(string userName, string password);

        void SignUp(User user);
    }
}
