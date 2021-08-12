using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp___WebBlog.Services.Iterfaces
{
    internal interface ISlugService
    {
        string UrlFriendly(string title);

        //determine if slug is unique or not
        bool SlugIsUnique(string slug);
    }
}