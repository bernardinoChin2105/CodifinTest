using APITests.Mocks;
using CodifinAPI.Controllers;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace APITests.Units
{
    public class CommentsUnitTest
    {
        CommentsController _Controller;
        IPostsService _PostsService;
        ICommentsService _CommentsService;

        public CommentsUnitTest()
        {
            _PostsService = new PostsServiceMock();
            _CommentsService= new CommentsServiceMock();
            _Controller = new CommentsController(_CommentsService, _PostsService);
        }

        [Fact]
        public void Comments_InitializeData_OkResponse()
        {
            var OkResult = _Controller.InitializeData();
            var CodeResult = Assert.IsType<OkResult>(OkResult as OkResult);
            Assert.True(CodeResult.StatusCode == StatusCodes.Status200OK);

        }        
    }
}
