using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp___WebBlog.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Text { get; set; }

        //Nav Prop
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}