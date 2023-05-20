using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using DataLayer;
using ServiceLayer;
using Integrations;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace APITests.Integral
{
    public class ServiceLayerIntegralTest
    {
        //Fixed ConnectionString
        public string DBConnectionString => "server=LAPTOP-08VR2903\\BCHIN_ENSITECH;database=CodifinDB;Integrated Security=true;Persist Security Info=false;";

        IPlaceHolderService _PlaceHolderService;
        IPostsService _PostsService;
        ICommentsService _CommentsService;
        IUsersService _UserService;
        CodifinDBContext _Context;

        public ServiceLayerIntegralTest()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(DBConnectionString);

            _Context = new CodifinDBContext(builder.Options);
            _PlaceHolderService = new PlaceHolderService();
            _PostsService = new PostsService(_Context, _PlaceHolderService);
            _CommentsService = new CommentsService(_Context, _PlaceHolderService);
            _UserService = new UsersService(_Context);

            _Context.Database.EnsureCreated();
        }

        [Fact]
        public void Posts_Download_Ok()
        {
            //Take into account, the constraint rule for primary key.
            int TotalItems = _PostsService.DownloadPosts();
            Assert.True(TotalItems > 0);
        }

        [Fact]
        public void Comments_Download_Ok()
        {
            //Take into account, the constraint rule for primary key.
            int TotalItems = _CommentsService.DownloadComments();
            Assert.True(TotalItems > 0);
        }

        [Fact]
        public void User_RegisterNew_Ok()
        {
            UserDTO Result = _UserService.CreateUser(new UserDTO
            {
                Name = "FixedName",
                UserName = "FixedUserName",
                Password = "FixedPassword"
            });

            Assert.True(Result.Id != 0);
        }

        [Fact]
        public void User_Verify_Ok()
        {
            //Ideally, this method should be tested after the real user insertion into the DataBase.
            UserDTO Result = _UserService.VerifyUser("FixedUserName", "FixedPassword");

            Assert.True(Result.Id != 0);
            Assert.True(Result.Name == "FixedName");
            Assert.True(Result.Password == "FixedPassword");
        }
    }
}
