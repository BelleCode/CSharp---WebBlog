using System;
using System.ComponentModel.DataAnnotations;

namespace CSharp___WebBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }

        // Foreign key
        public int PostId { get; set; }

        public string BlogUserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; } //Nullable b/c someone may NOT have updated

        [Required]
        [Display(Name = "(500 characters or less)")]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Body { get; set; }

        // Pav Props
        public virtual Post Post { get; set; }

        public virtual BlogUser BlogUser { get; set; }
    }
}