using BESProject.YoutubeVideoTree.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BESProject.YoutubeVideoTree.Entities.Concrete
{
    public class User: ITable
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
