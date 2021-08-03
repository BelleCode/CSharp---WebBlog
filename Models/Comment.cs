using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace CSharp___WebBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int PostId { get; set; } // Foreign key

        public string AuthorId { get; set; }
        public string ModeratorId { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        [Display(Name = "(500 characters or less)")]
        public string Body { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; } //Nullable b/c someone may NOT have updated
        public DateTime? Moderated { get; set; }
        public DateTime? Deleted { get; set; }

        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Moderated Comment")]
        public string ModeratedBody { get; set; }

        //Navigation Properties
        public virtual Post Post { get; set; }

        public virtual IdentityUser Author { get; set; }
        public virtual IdentityUser Moderator { get; set; }
    }
}