using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CommentUpdateDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be at least 5 character")]
        [MaxLength(50, ErrorMessage = "Title must be at most 50 character")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Content must be at least 5 character")]
        [MaxLength(280, ErrorMessage = "Content must be at most 280 character")]
        public string Content { get; set; } = string.Empty;
    }
}