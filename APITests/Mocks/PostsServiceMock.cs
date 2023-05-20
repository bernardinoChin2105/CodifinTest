using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace APITests.Mocks
{
    class PostsServiceMock : IPostsService
    {
        public int DownloadPosts()
        {
            //Execute operations for downloading third party data
            //and saving these on the DataBase.

            //Particular case returns 10 as successfull items inserted.
            return 10;
        }

        public IQueryable<PostDTO> GetAll()
        {
            List<PostDTO> Items = new List<PostDTO>() {
                new PostDTO(){
                    Id= 1,
                    UserId=1,
                    Title="Post 1 Title",
                    Body= "Post 1 Body",
                    Comments = new List<CommentDTO>{
                        new CommentDTO{
                            Id=1,
                            PostId=1,
                            Name="Post 1 Comment 1 Name",
                            Body= "Post 1 Comment 1 Body",
                            Email= "Post1Comment1@gmail.com"
                        },
                        new CommentDTO{
                            Id=2,
                            PostId=1,
                            Name="Post 1 Comment 2 Name",
                            Body= "Post 1 Comment 2 Body",
                            Email= "Post1Comment2@gmail.com"
                        }
                    }
                },
                new PostDTO(){
                    Id= 2,
                    UserId=1,
                    Title="Post 2 Title",
                    Body= "Post 2 Body",
                    Comments = new List<CommentDTO>{
                        new CommentDTO{
                            Id=3,
                            PostId=2,
                            Name="Post 2 Comment 1 Name",
                            Body= "Post 2 Comment 1 Body",
                            Email= "Post2Comment1@gmail.com"
                        },
                        new CommentDTO{
                            Id=4,
                            PostId=2,
                            Name="Post 2 Comment 2 Name",
                            Body= "Post 2 Comment 2 Body",
                            Email= "Post2Comment2@gmail.com"
                        }
                    }
                },
                new PostDTO(){
                    Id= 3,
                    UserId=1,
                    Title="Post 3 Title",
                    Body= "Post 3 Body",
                    Comments = new List<CommentDTO>{
                        new CommentDTO{
                            Id=5,
                            PostId=3,
                            Name="Post 3 Comment 1 Name",
                            Body= "Post 3 Comment 1 Body",
                            Email= "Post3Comment1@gmail.com"
                        },
                        new CommentDTO{
                            Id=6,
                            PostId=3,
                            Name="Post 3 Comment 2 Name",
                            Body= "Post 3 Comment 2 Body",
                            Email= "Post3Comment2@gmail.com"
                        }
                    }
                },
                new PostDTO(){
                    Id= 4,
                    UserId=1,
                    Title="Post 4 Title",
                    Body= "Post 4 Body",
                    Comments = new List<CommentDTO>{
                        new CommentDTO{
                            Id=7,
                            PostId=4,
                            Name="Post 4 Comment 1 Name",
                            Body= "Post 4 Comment 1 Body",
                            Email= "Post4Comment1@gmail.com"
                        },
                        new CommentDTO{
                            Id=8,
                            PostId=4,
                            Name="Post 4 Comment 2 Name",
                            Body= "Post 4 Comment 2 Body",
                            Email= "Post4Comment2@gmail.com"
                        }
                    }
                },
                new PostDTO(){
                    Id= 5,
                    UserId=1,
                    Title="Post 5 Title",
                    Body= "Post 5 Body",
                    Comments = new List<CommentDTO>{
                        new CommentDTO{
                            Id=9,
                            PostId=5,
                            Name="Post 5 Comment 1 Name",
                            Body= "Post 5 Comment 1 Body",
                            Email= "Post5Comment1@gmail.com"
                        },
                        new CommentDTO{
                            Id=10,
                            PostId=5,
                            Name="Post 5 Comment 2 Name",
                            Body= "Post 5 Comment 2 Body",
                            Email= "Post5Comment2@gmail.com"
                        }
                    }
                },
                new PostDTO(){
                    Id= 6,
                    UserId=1,
                    Title="Post 6 Title",
                    Body= "Post 6 Body",
                    Comments = new List<CommentDTO>{
                        new CommentDTO{
                            Id=11,
                            PostId=6,
                            Name="Post 6 Comment 1 Name",
                            Body= "Post 6 Comment 1 Body",
                            Email= "Post6Comment1@gmail.com"
                        },
                        new CommentDTO{
                            Id=12,
                            PostId=6,
                            Name="Post 6 Comment 2 Name",
                            Body= "Post 6 Comment 2 Body",
                            Email= "Post6Comment2@gmail.com"
                        }
                    }
                },
                new PostDTO(){
                    Id= 7,
                    UserId=1,
                    Title="Post 7 Title",
                    Body= "Post 7 Body",
                    Comments = new List<CommentDTO>{
                        new CommentDTO{
                            Id=13,
                            PostId=7,
                            Name="Post 7 Comment 1 Name",
                            Body= "Post 7 Comment 1 Body",
                            Email= "Post7Comment1@gmail.com"
                        },
                        new CommentDTO{
                            Id=14,
                            PostId=7,
                            Name="Post 7 Comment 2 Name",
                            Body= "Post 7 Comment 2 Body",
                            Email= "Post7Comment2@gmail.com"
                        }
                    }
                },
                new PostDTO(){
                    Id= 8,
                    UserId=1,
                    Title="Post 8 Title",
                    Body= "Post 8 Body",
                    Comments = new List<CommentDTO>{
                        new CommentDTO{
                            Id=15,
                            PostId=8,
                            Name="Post 8 Comment 1 Name",
                            Body= "Post 8 Comment 1 Body",
                            Email= "Post8Comment1@gmail.com"
                        },
                        new CommentDTO{
                            Id=16,
                            PostId=8,
                            Name="Post 8 Comment 2 Name",
                            Body= "Post 8 Comment 2 Body",
                            Email= "Post8Comment2@gmail.com"
                        }
                    }
                },
                new PostDTO(){
                    Id= 9,
                    UserId=1,
                    Title="Post 9 Title",
                    Body= "Post 9 Body",
                    Comments = new List<CommentDTO>{
                        new CommentDTO{
                            Id=17,
                            PostId=9,
                            Name="Post 9 Comment 1 Name",
                            Body= "Post 9 Comment 1 Body",
                            Email= "Post9Comment1@gmail.com"
                        },
                        new CommentDTO{
                            Id=18,
                            PostId=9,
                            Name="Post 9 Comment 2 Name",
                            Body= "Post 9 Comment 2 Body",
                            Email= "Post9Comment2@gmail.com"
                        }
                    }
                },
                new PostDTO(){
                    Id= 10,
                    UserId=1,
                    Title="Post 10 Title",
                    Body= "Post 10 Body",
                    Comments = new List<CommentDTO>{
                        new CommentDTO{
                            Id=19,
                            PostId=10,
                            Name="Post 10 Comment 1 Name",
                            Body= "Post 10 Comment 1 Body",
                            Email= "Post10Comment1@gmail.com"
                        },
                        new CommentDTO{
                            Id=20,
                            PostId=10,
                            Name="Post 10 Comment 2 Name",
                            Body= "Post 10 Comment 2 Body",
                            Email= "Post10Comment2@gmail.com"
                        }
                    }
                }
            };

            return Items.AsQueryable();            
        }
    }
}
