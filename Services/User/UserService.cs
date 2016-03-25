using DAL.DataContext;
using DAL.Entities;
using DAL.Repository;
using DAL.UnitOfWork;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.User
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _userRepository;

        public UserService(IRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(string email)
        {
            _userRepository.Add(new UserEntity
            {
                Email = email
            });
        }
    }
}
