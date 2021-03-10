using System;
using System.Collections.Generic;
using Google.Protobuf.Collections;
using Grpc.Net.Client;
using GrpcDemo.Protos;

namespace GrpcConsoleTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new User.UserClient(channel);

            //CreateUserTest(client);
            //GetUserTest(client);
            CreateUserDetailTest(client);

        }

        private static UserModelResult CreateUserDetailTest(User.UserClient client)
        {
            var phones = new RepeatedField<UserPhone>
            {
                new UserPhone{Fax="1",Skypeid="S1"},
                new UserPhone{Fax="2",Skypeid="S2"},
                new UserPhone{Fax="3",Skypeid="S3"},
            };

            return client.CreateUserDetail(new UserDetail
            {

                Usermodel = new UserModel
                {
                    Age = 21,
                    Adress = "Subu 2",
                    Name = "ishakdolek"
                },
                Uphone =
                       {
                           new UserPhone{Fax="1",Skypeid="S1"},
                           new UserPhone{Fax="2",Skypeid="S2"},
                           new UserPhone{Fax="3",Skypeid="S3"},
                       }

                //Phone = new RepeatedField<Phone>()


            });
        }

        private static void GetUserTest(User.UserClient client)
        {
            var getUser = client.GetUserInfo(new UserRequest
            {
                Id = 2
            });

            Console.WriteLine(getUser);
        }

        private static void CreateUserTest(User.UserClient client)
        {
            for (var i = 0; i < 5; i++)
            {
                var response = client.CreateUser(new UserModel
                {
                    Adress = "Subu Yazılım",
                    Name = "ishakdolek",
                    Age = 30
                });
                Console.WriteLine(response.Message);

            }

        }
    }
}
