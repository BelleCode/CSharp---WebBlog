﻿using CSharp___WebBlog.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        [Display(Name = "Blog Name")]
        public int BlogId { get; set; }

        [Display(Name = "Blog Name")]
        public string BlogUserId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Title { get; set; }

        [Required] // used to draw the reader
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Abstract { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }

        public ReadyStatus ReadyStatus { get; set; }

        public string Slug { get; set; }

        // Addingthe properties for for describing any images being used
        [Display(Name = "Blog Image")]
        public string ImageType { get; set; }

        [Display(Name = "Image Type")]
        public byte[] ImageData { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        //Navigation Property
        public virtual Blog Blog { get; set; }

        public virtual BlogUser BlogUser { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    }
}