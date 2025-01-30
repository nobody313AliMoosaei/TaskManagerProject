using TaskManagerRoom308.Data.Database;
using TaskManagerRoom308.Data.Entities;
using TaskManagerRoom308.DTO.AddNewUser;

namespace TaskManagerRoom308.Services
{
    public class UserService
    {
        private Application_dbContext _DbContext;
        public UserService(Application_dbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<bool>addNewUser(addNewUserCommand command)
        {
            var entity = new User
            {
                FirstName = command.FisrtName,
                LastName = command.LastName,
                PhoneNumber = command.PhoneNumber,
                NationalCode = command.NationalCode,
                Email = command.Email,
                Password = command.Password
            };
            _DbContext.Users.Add(entity);
            await _DbContext.SaveChangesAsync();
            return true;
        }





    }

}
