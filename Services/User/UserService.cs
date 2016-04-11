using DAL;
using DAL.DataContext;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.User
{
    public class UserService : IUserService
    {
        //private IRepository<UserEntity> _userRepository;

        //public UserService(IRepository<UserEntity> userRepository)
        //{
        //    _userRepository = userRepository;
        //}

        public void AddUser(string email)
        {
            using(var context = new ApplicationDbContext())
            {
                context.User.Add(new UserEntity
                {
                    Email = email
                });

                context.SaveChanges();
            }
            
        }
    }
}
