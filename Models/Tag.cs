using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp___WebBlog.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int AuthorId { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Text { get; set; }

        //Nav Prop
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();

        public virtual IdentityUser Author { get; set; }
    }
}