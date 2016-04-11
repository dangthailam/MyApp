using DAL;
using DAL.Entities;

namespace MyApp.Services.User
{
    public class UserService : IUserService
    {
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
