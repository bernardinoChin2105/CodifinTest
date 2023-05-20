using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace APITests.Mocks
{
    class CommentsServiceMock : ICommentsService
    {
        public int DownloadComments()
        {
            //Execute operations for downloading third party data
            //and saving these on the DataBase.

            //Particular case returns 20 as successfull items inserted.
            return 20;
        }        
    }
}
