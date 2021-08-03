using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp___WebBlog.Models
{
    public class Post
    {
        public int Id { get; set; }

        // BlogId == my foreign key (FK) Ca combination of a classs property key and the the blog key
        public int BlogId { get; set; }

        [Display(Name = "Blog Name")]
        public int BlogID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Title { get; set; }

        // used to draw the reader
        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Abstract
        { get; set; }

        // the content
        [Required]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }

        public string Slug { get; set; }

        /*public byte[] ImageData { get; set; }
        public string ContentType { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }*/

        [Display(Name = "Select Image")]
        public IFormFile Image { get; set; }

        //Parent of the yet to be defined Comment class (Comment Type)
        // Indicates this is a child of BlogID
        public virtual Blog Blog { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    }
}