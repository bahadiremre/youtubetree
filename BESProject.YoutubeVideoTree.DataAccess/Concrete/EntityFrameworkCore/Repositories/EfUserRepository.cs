using BESProject.YoutubeVideoTree.DataAccess.Concrete.Contexts;
using BESProject.YoutubeVideoTree.DataAccess.Interfaces;
using BESProject.YoutubeVideoTree.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESProject.YoutubeVideoTree.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfUserRepository : IUserDal
    {
        public bool CheckUserLogin(string userName, string password)
        {
            using var context = new SqlDbContext();
            var user = context.Set<User>().FirstOrDefault(x => x.UserName == userName && x.Password == password);

            //return user != null;

            return user != null;
        }

        public void SignUp(User user)
        {
            using var context = new SqlDbContext();
            context.Set<User>().Add(user);
            context.SaveChanges();
        }
    }
}
