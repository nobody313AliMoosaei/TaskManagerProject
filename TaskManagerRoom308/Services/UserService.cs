using Microsoft.EntityFrameworkCore;
using TaskManagerRoom308.Data.Database;
using TaskManagerRoom308.Data.Entities;
using TaskManagerRoom308.DTO;
using TaskManagerRoom308.DTO.AddNewUser;
using TaskManagerRoom308.DTO.DeletUser;
using TaskManagerRoom308.DTO.GetAllUser;

namespace TaskManagerRoom308.Services
{
    public class UserService
    {
        private Application_dbContext _DbContext;
        public UserService(Application_dbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<bool> addNewUser(addNewUserCommand command)
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
        public async Task<bool> DeletUser(DeletUserCommand command)
        {
            var User = await _DbContext.Users.Where(e => e.Id == command.Userid).FirstOrDefaultAsync();
            if (User is not null)
            {
                var USerTasks = await _DbContext.UserTasks.Where(e => e.UserRef == command.Userid).ToListAsync();
                _DbContext.UserTasks.RemoveRange(USerTasks);
                _DbContext.Users.Remove(User);
                await _DbContext.SaveChangesAsync();
            }
            return true;
        }
        public async Task<ResponseData<List<GetAllUserQr>>> GetAllUser(MetaDataDTO query)
        {
            ResponseData<List<GetAllUserQr>> res = new();

            var _queryResult = _DbContext.Users
                .Select(e => new GetAllUserQr
                {
                    UserId = e.Id,
                    FullName = e.FirstName + " " + e.LastName,
                    NationalCode = e.NationalCode,
                    PhoneNumber = e.PhoneNumber,
                    Email = e.Email
                }).AsQueryable();

            res.Data = await _queryResult.OrderBy(e => e.UserId).Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize).ToListAsync();
            res.SetValueMetaData(await _queryResult.CountAsync(), query.PageSize, query.PageNumber);
            return res;

        }
    }
}
