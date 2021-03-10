using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Grpc.Core;
using GrpcDemo.Protos;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using GrpcDemo.Context;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace GrpcDemo.Services
{
    public class UserService : User.UserBase
    {

        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public override Task<UserModel> GetUserInfo(UserRequest request, ServerCallContext context)
        {
            return Task.FromResult(GetUserInfoFromDb(request));
        }

        public override Task<UserModelResult> CreateUser(UserModel request, ServerCallContext context)
        {
            return  Task.FromResult(CreateUser(request));
        }
        
        public override Task<UserModelResult> CreateUserDetail(UserDetail request, ServerCallContext context)
        {

            CreateUserDetail(request);
            


            return Task.FromResult(new UserModelResult());
        }

        private void CreateUserDetail(UserDetail request)
        {
            using var context = new  UserContext();
            var user = new Entities.User
            {
                Name = request.Usermodel.Name,
                Adress = request.Usermodel.Adress,
                Age = request.Usermodel.Age
            };
            context.User.Add(user);
            context.SaveChanges();

            var phones = request.Uphone.Select(x => new Entities.Phone
            {
                Fax = x.Fax,
                SkypeId = x.Skypeid,
                UserId = user.Id
            }).ToList();

            context.Phone.AddRange(phones);
            context.SaveChanges();
        }
        
        private static UserModelResult CreateUser(UserModel model)
        {
            using (var context = new UserContext())
            {
                var addUser = new Entities.User
                {
                    Name = model.Name,
                    Age = model.Age,
                    Adress = model.Adress
                };
                context.User.Add(addUser);
                context.SaveChanges();
            }

            return new UserModelResult
            {
                Message = "User Created Code:201"
            };
        }

        private static UserModel GetUserInfoFromDb(UserRequest request)
        {
            var result = new UserModel();
            using var context = new UserContext();
            var firstOrDefault = context.User.FirstOrDefault(x => x.Id == request.Id);
            if (firstOrDefault == null) return result;
            result.Adress = firstOrDefault.Adress;
            result.Name = firstOrDefault.Name;
            result.Age = firstOrDefault.Age;

            return result;
        }

    }
}
