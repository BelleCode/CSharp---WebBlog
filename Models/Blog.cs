using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSharp___WebBlog.Models
{
    public class Blog
    {
        public int Id { get; set; }

        // public string AuthorId {get;set} for more than one author
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description (500 characters or less)")]
        // Is it possible to include a countdown
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Updated { get; set; } // short hand "public Nullable<DateTime> Updated { get; set; }"

        // Navigational Properties - These properties allow us to move from one object to another related
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();

        //TIGHT COUPLING: public virtual List<Post> Posts { get; set; } = new List<Post>();

        // Addingthe properties for for describing any images being used
        public string ImageType { get; set; }

        public byte[] ImageData { get; set; }

        [Display(Name = "Select Image")]
        public IFormFile Image { get; set; }
    }
}