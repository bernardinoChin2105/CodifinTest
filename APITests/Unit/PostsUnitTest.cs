using APITests.Mocks;
using CodifinAPI.Controllers;
using CodifinAPI.Models;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace APITests.Units
{
    public class PostsUnitTest
    {
        PostsController _Controller;
        IPostsService _Service;

        public PostsUnitTest()
        {
            _Service = new PostsServiceMock();
            _Controller = new PostsController(_Service);
        }

        [Fact]
        public void Posts_InitializeData_OkResponse()
        {
            var OkResult = _Controller.InitializeData();

            var CodeResult = Assert.IsType<OkResult>(OkResult as OkResult);
            Assert.True(CodeResult.StatusCode == StatusCodes.Status200OK);

        }

        [Fact]
        public void Posts_GetAll_OkResponse()
        {
            var OkResult = _Controller.GetAll();

            Assert.IsType<OkObjectResult>(OkResult.Result as OkObjectResult);
        }

        [Fact]
        public void Posts_GetAll_OkItemType()
        {
            var OkResult = _Controller.GetAll();

            Assert.IsType<List<PostResponse>>((OkResult.Result as ObjectResult).Value);
        }

        [Fact]
        public void Posts_GetAll_OkTotalItems()
        {
            var OkResult = _Controller.GetAll();

            Assert.True(((OkResult.Result as ObjectResult).Value as List<PostResponse>).Count == 10);
        }

        [Fact]
        public void Posts_GetPaginated_Ok()
        {
            var OkResult = _Controller.Get(10, 1, 1);

            Assert.IsType<OkObjectResult>(OkResult.Result as OkObjectResult);
        }

        [Fact]
        public void Posts_GetPaginated_OkItemType()
        {
            var OkResult = _Controller.Get(10, 1, 1);

            Assert.IsType<PaginatedPost>((OkResult.Result as OkObjectResult).Value);
        }

        [Fact]
        public void Posts_GetPaginated_OkTotalItems()
        {
            var OkResult = _Controller.Get(10, 1, 1);
            Assert.True(((OkResult.Result as ObjectResult).Value as PaginatedPost).TotalRows == 10);
        }

        [Fact]
        public void Posts_GetPaginated_OkPagination()
        {
            var OkResult = _Controller.Get(5, 2, 1);

            var Result= Assert.IsType<PaginatedPost>((OkResult.Result as OkObjectResult).Value);
            Assert.True(Result.TotalRows == 10);
            Assert.True(Result.PrevPage == "1");
            Assert.True(Result.NextPage == null);
            Assert.True(Result.Data[0].Id == 6);
        }
    }
}
